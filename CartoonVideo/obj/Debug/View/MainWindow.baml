   M S B A M L   `   `   `  ����G  CCartoonVideo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CartoonVideo.ViewCartoonVideo.View  5   	   ?$clr-namespace:CartoonVideo.ViewModelCartoonVideo.ViewModel  5   	   7 clr-namespace:CartoonVideo.UtilsCartoonVideo.Utils  5   	   "    CartoonVideo.View.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CartoonVideo.View     5   	   :	viewModel$clr-namespace:CartoonVideo.ViewModel     5   	   4helpers clr-namespace:CartoonVideo.Utils     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)    � DataContext 5      !  CartoonVideo.ViewModel.Main  5   
   .��5      � .+�5   
   �� $
��Left=�6a   $	��100��6|   $��55.048,51.095,0,0q�6�   
���   �$	��Top=�6�   $	��100��6�   ��6   �� *	RandColor+   ColorToBrushConverter �� 	Converter# [  6�   �� 5   
   $
��Left=�6b   $	��100��6}   $��523.619,51.095,0,0q�6�   
���   �$	��Top=�6�   $	��100��6�   ��6   �� *
MatchColor+# [  6�   �� 5   
   $��Random Color��6   $
��Left=�6(   $��55.048,247.285,0,0q�6C   $	��Top=�6_   $��75��6w   ��6�   �� *RandomColorCommand+ �� Mode$ OneWay=��� 5   
   $��Match��6   $
��Left=�6!   $��523.619,247.285,0,0q�6<   $	��Top=�6Y   $��75��6q   ��6|   �� *MatchColorCommand+$ OneWay=��� 5   
   $��0,348.571,0,0q�65   ��6   �� *	ColorList+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   5      ��5      �� 5      .R�5      �� $��20��6h   $��20��6v   ��6    �� *color+# [  6v   5      5       �� 5!   
   $��Choose Image��6   $
��Left=�6(   $��258.857,222.523,0,0q�6C   $	��Top=�6`   $��75��6x   ��6�   �� *ChooseImageCommand+$ OneWay=�5"      5#      