   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      W SOpenSerialPortMonitor, Version=1.0.7978.29887, Culture=neutral, PublicKeyToken=nullq=clr-namespace:Whitestone.OpenSerialPortMonitor.Main.Framework/Whitestone.OpenSerialPortMonitor.Main.Framework 5      D   >Whitestone.OpenSerialPortMonitor.Main.Views.SerialDataSendView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^ ZCaliburn.Micro.Platform, Version=2.0.2.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      Ilocal=clr-namespace:Whitestone.OpenSerialPortMonitor.Main.Framework  5      $y�Hidden=�5
   6   .��5      � .+�5   
   �� $��0��6   ���	#FF8e9bbc$��1q�66   ���	#FFcfd6e5  �� EdgeMode$  Aliased=�6b   ._�5      �  � RowDefinitions 5      �� 5      $��21 �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��0��6   $��	Send data��6%   ���	#FF4d6082
�������$��5,2,0,0q�6c   6w   �� 5      $��1��6   $��Data to send:��6%   $��80��6=   $	��Top=�6H   $
��Left=�6`   $��5q�6{   6�   �� 5      -   5         ��Name$ 
DataToSend��5   J   $��1��6   ���	#FFFFFFFF$��5q�6>    �� IsUndoEnabled .  �� TextWrapping$ NoWrap=�6s   $��Courier New)�6�   $	��Top=�6�   $��85,5,5,5q�6�   .��6�   .   (System.Windows.Interactivity.Interaction   Triggers 5      I  CWhitestone.OpenSerialPortMonitor.Main.Framework.InputBindingTrigger  5         InputBinding 5      �� 5   "   
 �� Key$ Enter��6-   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      "  Caliburn.Micro.ActionMessage  	   
MethodName$	 DoSend��60   5      .��5   .   5      �� 5!      $��2��6   $��Data format:��6%   $��80��6<   $	��Top=�6G   $
��Left=�6_   $��5,0,5,5q�6z   6�   	� 5"      -   5        
 	�Name$
 IsText��5"   c   $��2��6   $��85,7,5,5q�6+   $
��Text��6=    	� 	GroupName$ 
DataFormat��6L   6c   	� 5#      -   5        $
 IsHex��5#   c   $��2��6   $��	140,7,5,5q�6+   $	��Hex��6>   $ 
DataFormat��6L   6c   �� 5$      -   5         ��Name$ DoSend��5$   �   $��2��6   $
��Send��6&   $��Right=�65   $��Center=�6Q   $��5,0,5,5q�6l   $��	15,4,15,4q�6}   {�6�   �� *IsValidData+6�   5&      5'      5(      5)      