   M S B A M L   `   `   `  ���� B  >Karaoke, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Karaoke.ViewModelsKaraoke.ViewModels      Karaoke.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  ,local clr-namespace:Karaoke.ViewModels  b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a10	mvvmlight http://www.galasoft.ch/mvvmlight  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Hcommand:http://schemas.microsoft.com/expression/2010/interactivity    � WindowStyle$
  None=� � AllowsTransparency$
 True�� � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=�$	��240��$��42�� � Title$ 
MainWindow��$	��600��$	��800����Z�  � DataContext &   Karaoke.ViewModels.MainViewModel  .����  �� CornerRadius$ 10��._�� .+�� -      
Background#���   $��30��$	��Top=� � RowDefinitions �� $��5 ��� $��25 � � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��5 �.+��� $��Karaoke��  WindowTitle#���  $��1���� $��1��$��1��  OperationButton#���  $��20��$��20����0  *MaterialDesignThemes.Wpf.PackIconExtension  	   Kind$	 Pause=����� *PauseCommand+�� $��2��$��1��#���  ���� *PlayCommand+��  $
	 Play=�
   Size
 15�� #���  $��3��$��1����  $	 Settings=�
 15���� *OpenSettingsCommand+����  �� ElementName$ Settings���� $��4��$��1��#���  ��  $	 WindowMinimize=�
 15���� *MinimizeCommand+����  �� RelativeSource ��  �� AncestorType
 Border�� $��5��$��1��#���  ��  $	 Maximize=�
 15���� *MaximizeCommand+����  �� 
 Border�� $��6��$��1��#���  ��  $	 	CloseBold=�
 15���� *CloseAnimation+����  �� 
 Border�� $��0,29,0,0q����� $ BackgroundColorPicker�� �� Path$ Color�  ColorConverter �� 	Converter# [ ._�� .+���  
 Header#���  $
��Wrap=� �� TextAlignment$ Center=�$��72(����� *Row+���� $ ForegroundColorPicker��$ Color�# [ �� -    ��Name$ Settings��#���    K� ZIndex$ 1��$��0,29,0,0q�y��� *SettingsVisibility+._��� $
��Auto=�.���� $	��800��.+���   Section#���  ._��� .+��� $��Color settings��#���  � $	��500�� �� $��2* ��� $
��0.5* ��� $��2* � �� $��40 ��� $
��3.5* ��� $��40 ��� $��2* ��� $��40 �.+���   TextBoxBackground#���  ._��� $��
Foreground��#���  *  $MaterialDesignThemes.Wpf.ColorPicker  -   $��ForegroundColorPicker��$��1��$
��0,10q�   Color �� *SelectedForegroundColor+�� $��2��#���  ._��� ���� $ ForegroundColorPicker��$ Color��� #���  $��2��._��� $��
Background��#���    -   $��BackgroundColorPicker��$��1��$��2��$
��0,10q� �� *SelectedBackgroundColor+�� $��2��#���  $��2��._��� ���� $ BackgroundColorPicker��$ Color��� $��3��$��3��$	��300��$��10q����� $ BackgroundColorPicker��$ Color�# [ ._��� $��Example��#���  ���� $ ForegroundColorPicker��$ Color�# [ ��   	BigButton#���  $
��Save��$��15(�$��3��$��4��$	��300������ *SaveColorCommand+�� #���  ._��� .+��� $��Select file settings��#���  $��30,20,30,30q�� $
��Left=�$	��610��$��20,0,0,0q� �� $��1* ��� $��30 ��� $��2* � �� $��40 ��� $��40 ��� $��40 �.+��� $��Select text file��#���  $��5q��� #���  $��1����  $	 FileDocument=����� *OpenTextFileCommand+�� $��Select audio file��#���  $��1��$��5q��� #���  $��1��$��1����  $	 	FileMusic=����� *OpenAudioFileCommand+�� $��All time��#���  $��2��$��5q��� #���  $��2��$
��40,0q�$��Right=�._��� $��15(����� *
AllTimes+�� #���  $��1��$��2����  $	 CheckAll=����� *ApplyAllTimesCommand+�� #���  $��2��._��� ���� *TextFilePath+�� #���  $��2��$��1��._��� ���� *AudioFilePath+�� $1��+Use this when you need apply it to all time��#���  $��2��$��2���� #���  ._��� .+��� $��Text settings��#���  �� $	��350��$
��Auto=�.���� ���� *Rows+���� .R��� ���� .R�� $	��0,5q� �� $��5* ��� .+��� #���  ._���   ItemsControlRows#���  ���� *Row+�� #���  $��1��._��� ���� *Time+�� #���  ._��� .+���  �� Orientation$ 
Horizontal=�$��RightToLeft=�.+��� #���  $��10q���  $	 Delete=����� *DeleteMarkerCommand+�� #���  $��10q���  $	 CircleArrows=����� *ClearMarkersCommand+�� $��20,0,0,0q� 	 PrimaryText#��� 	 ���� *TimePoints.Count+ �� StringFormat$ Count : {0}���� $��Visible=�$��Hidden=�.���� $��Center=����� *
TimePoints+���� .R��  � Orientation$ 
Horizontal=����� .R�	�  

 Marker#��� 
 ���� ���� *#!DataContext.SelectedMarkerCommand+ ��  ItemsControl���� �� #���  ._��� .+�� $	��120�� �� �� ��  �� $��30 ��� $��30 ��� .+��� #��� 	 $��10q����� *CurrentPosition+$ 
{0:mm\:ss}���� #���  $��1����  $	 
MarkerTick=�
 12���� *AddTimePointCommand+�� #��� 	 $��10q�$��2��$��Right=����� *
Duration+$ 
{0:mm\:ss}���� $��3��$��1�� � Maximum �� *Duration.TotalSeconds+ � Value �� *CurrentPosition.TotalSeconds+ �� Mode$ OneWay=��� $��2��$ 
Horizontal=�$��Center=�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
VolumeHigh=�  
Foreground#���  $��30��$��30���� $	��100��$ 1Q� � Minimum$ 0Q� �� *Player.Volume+A�  A� Columns$ 3��$��2��$��1��.+���   MediaPlayerButton#���  ���� *RewindCommand+��  $	 Rewind10=�d�   MediaPlayerBigButton#���  ���� *PlayPauseCommand+�� #���  ��  $	 FastForward10=����� *FastForwardCommand+�� $ 
Horizontal=�$��RightToLeft=�$��2��$��2��$��10q�.+��� $��20��$��20��#���  $ 10��._��� $��R��$��Center=�$��Center=�#���     ButtonContent#���  �� $	��100��$ 1Q�$ 0Q� �� *Player.Balance+�� $��20��$��20��#���  $ 10��._��� $��L��$��Center=�$��Center=�#���   #���  