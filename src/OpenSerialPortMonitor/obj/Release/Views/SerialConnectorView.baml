   M S B A M L   `   `   `  ����   OpenSerialPortMonitorE    ?Whitestone.OpenSerialPortMonitor.Main.Views.SerialConnectorView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources      booleanToVisibilityConverter��%   &	        �� .���� ���	#FF8e9bbc$��1,1,1,1q� �� Padding$ 
5, 3, 5, 5q����	#FFcfd6e5 �� EdgeMode$ Aliased=�._�� $
��Left=�$	��Top=� � ColumnDefinitions �� $	��100 ��� $��* � � RowDefinitions �� $��21 ��� $��25 ��� $��25 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��2��$��Serial port connection�����	#FF4d6082
�������$��
-5,-3,-5,2q�$��5,2,0,0q��� $��1��$��0��$��	COM port:���� -    ��Name$ ComPorts��$��1��$��1��$��Center=�{��� *IsDisconnected+ �� SelectedItem �� *SelectedComPort+�� $��2��$��0��$��
Baud rate:���� -   $ 	BaudRates��$��2��$��1��$��Center=�{��� *IsDisconnected+ �� *SelectedBaudRate+�� $��3��$��0��$��Parity:���� -   $ Parities��$��3��$��1��$��Center=�{��� *IsDisconnected+ �� *SelectedParity+�� $��4��$��0��$��
Data bits:���� -   $ DataBits��$��4��$��1��$��Center=�{��� *IsDisconnected+ �� *SelectedDataBits+�� $��5��$��0��$��
Stop bits:���� -   $ StopBits��$��5��$��1��$��Center=�$	��100��{��� *IsDisconnected+ �� *SelectedStopBits+�� -    ��Name$ Connect��$��6��$��2��$��Connect��$��30��$��0,5,0,0q�y��� *IsDisconnected+ �� 	Converter# [  �� -   $ 
Disconnect��$��6��$��2��$��
Disconnect��$��30��$��0,5,0,0q�y��� *IsConnected+# [  