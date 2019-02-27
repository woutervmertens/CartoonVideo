using System.Drawing;
using CartoonVideo.Utils;
using AForge.Video.FFMPEG;
using System.Windows.Input;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace CartoonVideo.ViewModel
{
    class Main : INotifyPropertyChanged
    {
        //Local data
        int width, height, frameRate;
        long frameCount;
        string codecName;
        Color p;
        private static ClosestPointFinder cpf;

        Bitmap[] bitmaps;

        string SourcePath, SavePath;

        //UI Data
        private Color _randColor;
        public Color RandColor
        {
            get { return _randColor; }
            set
            {
                _randColor = value;
                OnPropertyChanged("RandColor");
            }
        }

        private Color _matchColor;
        public Color MatchColor
        {
            get { return _matchColor; }
            set
            {
                _matchColor = value;
                OnPropertyChanged("MatchColor");
            }
        }

        public ObservableCollection<LocalColor> ColorList { get; set; }

        //Command
        private ICommand randomColor;
        public ICommand RandomColorCommand
        {
            get { return randomColor; }
        }
        private ICommand matchColor;
        public ICommand MatchColorCommand
        {
            get { return matchColor; }
        }

        public Main()
        {
            cpf = new ClosestPointFinder();
            //Set Commands
            randomColor = new Command(OnClickRandom);
            matchColor = new Command(OnClickMatch);

            //Fill points
            ColorList = new ObservableCollection<LocalColor>();
            ColorList.Add(new LocalColor(Color.Blue));
            ColorList.Add(new LocalColor(Color.Yellow));
            ColorList.Add(new LocalColor(Color.Red));
            ColorList.Add(new LocalColor(Color.Green));
            ColorList.Add(new LocalColor(Color.Purple));
            ColorList.Add(new LocalColor(Color.White));
            ColorList.Add(new LocalColor(Color.Black));
            int length = ColorList.Count;
            cpf.points = new Vector3[length];
            for (int i = 0; i < length; i++)
            {
                cpf.points[i] = new Vector3(ColorList[i].color.R,ColorList[i].color.G, ColorList[i].color.B);
            }
        }

        private void OnClickMatch()
        {
            MatchColor = SetClosestColor(RandColor);
        }

        private void OnClickRandom()
        {
            Random rnd = new Random();
            RandColor = Color.FromKnownColor((KnownColor)rnd.Next(1, 167));
        }

        private void LoadVideoImages()
        {
            using (var videoReader = new VideoFileReader())
            {
                videoReader.Open(SourcePath);

                width = videoReader.Width;
                height = videoReader.Height;

                frameRate = videoReader.FrameRate;
                frameCount = videoReader.FrameCount;
                bitmaps = new Bitmap[frameCount];

                codecName = videoReader.CodecName;

                for (int i = 0; i < frameCount; i++)
                {
                    bitmaps[i] = videoReader.ReadVideoFrame();
                }

                videoReader.Close();
            }
        }

        private Color SetClosestColor(Color c)
        {
            Vector3 old = new Vector3(c.R, c.G, c.B);
            Vector3 vnew = cpf.getClosestPointFromArray_Brute(old);

            return Color.FromArgb(c.A, (int)vnew.x, (int)vnew.y, (int)vnew.z);
        }

        private Bitmap EditColors(Bitmap bmp)
        {
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);

                    bmp.SetPixel(x, y, SetClosestColor(p));
                }
            }

            return bmp;
        }

        private void SaveImagesVideo()
        {
            using (var videoWriter = new VideoFileWriter())
            {
                videoWriter.Open(SavePath, width, height, frameRate, VideoCodec.MPEG4);

                for (int i = 0; i < frameCount; i++)
                {
                    videoWriter.WriteVideoFrame(bitmaps[i]);
                }

                videoWriter.Close();
            }
        }
        public class LocalColor
        {
            public LocalColor(Color c)
            {
                color = c;
            }
            public Color color { get; set; }
        }
        //OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
