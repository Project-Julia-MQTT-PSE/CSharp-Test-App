   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.MqttWpfApp2.Mqtt  5   	   !clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   #Mqttclr-namespace:WpfApp2.Mqtt  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5	   	   $	��350��6   $	��525��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��5* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   o� $
��Left=�6   $��20��6*   $	��Top=�66   $��4��6N   .@�5      m� $��
_Mosquitto��6   .@�5      m� -   5         m�Name$* $cmdConnectPublicMosquittoUnencrypted��5   1   $��_unencrypted��6   61   m� 5      -   5        $( "cmdConnectPublicMosquittoEncrypted��5   /   $��
_encrypted��6   6/   5      5      �� 5   
   $��	Publisher��6   $��24(�6%   $��1��63   $��1��6C   $��Center=�6P   $	��Top=�6m   �� 5   
   $��1��6   $��1��6%   $��Center=�62   $��20,20,20,20q�6M   .+�5      �� $��Topic��6   �� 5      -   5         ��Name$ txtTopic��5      �� 5       $��Message��6   �� 5!      -   5        $ 
txtMessage��5!      �� 5"      -   5         ��Name$ cmdSend��5"      $
��Send��6&   5#      �� 5$   
   $��
Subscriber��6   $��24(�6&   $��2��64   $��1��6D   $��Center=�6Q   $	��Top=�6n   �� 5%   
   $��2��6   $��1��6&   $��Center=�63   .+�5&      �� $��Topic��6   �� 5'      -   5        $ txtSubscribeTopic��5'      �� 5(      -   5        $ cmdSubscribe��5(      $��	Subscribe��6,   � 5)       5*      �� 5+      $��1* �6'   �� 5,      $��1* �6'   .+�5.      �� -   5         ��Name$ lbSubscribedTopics��5.      $��0��67   $	��110��6G   ��5/      �� 50      .R�51      �� .+�52   "   �� ��6,   �� 53      54      56      �� 57      -	   5        $ lbReceivedMessages��57      $��1��6N   $	��110��6^   ��66   �� ��58      �� 59      .R�5:      �� .+�5;   "   �� ��6,   �� *Topic+�� 5<   "   ��6,   �� *	Content+5=      5>      5@      5A      5B      �� 5D   
   $��2��6   $��4��6!   $��20��65   $��Bottom=�6A   .@�5E      �� .��5F      �� -
   5         ��Name$ chbConnectionStatus��5F   -   {�.  $��Not Connected��6J   5G      5H      5I      5J      