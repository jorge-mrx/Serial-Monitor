   M S B A M L   `   `   `  ����  OpenSerialPortMonitor:    4Whitestone.OpenSerialPortMonitor.Main.Views.MainView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��600��5      $	��800��6     � Icon$  openSerialPortMonIcon.png��6'   .��5      � ���	#FF2a3a56 � ColumnDefinitions 5	   
   �� 5
      $
��Auto �6   6.   �� 5      $
��631* �6   6.   �� 5      $
��151* �6    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $��* �6   6)   �� 5      $	��100 �6   6+   .+�5   
   o� $��0��6   $��0��6   $��3��6,   ���	#FFd6dbe9.@�5      m� $��_File��6   .@�5      m� -   5         m�Name$ FileExit��5   *   $��_Exit��6   6>   5      m� 5      $��_View��6   .@�5      m� -   5        $ 
Autoscroll��5   0   $��_Autoscroll��6    m� IsCheckable .  m� 	IsChecked . 6j   5      m� 5      $��_Help��6   .@�5      m� -   5        $ 	OpenAbout��5   +   $��_About��6   6@   5      5      �� 5   
   -   5         ��Name$ SerialConnectorView��5      $��0��66   $��1��6F   $��5,5,5,0q�6S   $	��Top=�6d   �� 5   
   -   5        $ SerialDataView��5      $��1��61   $��1��6A   $��0,5,5,5q�6N   $��Stretch=�6_   $��Stretch=�6�   $��2��6�   �� 5    
   -   5        $ SerialDataSendView��5       $��1��65   $��2��6E   $��0,0,5,5q�6R   $��Stretch=�6c   $��Stretch=�6�   $��2��6�   5!      5"      