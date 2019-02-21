using System.Drawing;
using AForge.Video.FFMPEG;

namespace CartoonVideo.ViewModel
{
    class Main
    {
        int width, height, frameRate;
        long frameCount;
        string codecName;
        Color p;

        Bitmap[] bitmaps;

        string SourcePath, SavePath;

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
            return c;
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
    }
}
