   M S B A M L   `   `   `  ���� B  >ScanITT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ScanITTScanITT      ScanITT.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:ScanITT       � Title$  ScanITT��$	��800��$	��800��.��� ���	#CC000000 � ColumnDefinitions �� $��2* ��� $��3* ��� $��1* � � RowDefinitions �� $��1* �.+��� $��0��$
��Left=�$��Stretch=����	#66000000.+��� $
��Scan��$��30(�$��50, 0, 20, 0q�
��������� $��Device name��$��70, 10, 20, 10q�
�������$��15(��� -    ��Name$ AvailableScanners�� J� RenderTransformOrigin$ 0.264,0.516&�$��45��$	��186���� $��	File type��$��70, 10, 20, 10q�
�������$��15(��� -   $ 	File_Type��$��4q�
����  � �� SelectedIndex$ 0��$ 0.264,0.516&�$��32��$	��194��.@��� $��
Image(PNG)���� $��
Image(Jpg)���� $��	File(Pdf)���� $��	File(PNG)����  �� Orientation$ 
Horizontal=�$��35, 20, 20, 0q�$��Bottom=�.+��� $��Bottom=�.+��� -    ��Name$ Save_Btn��$��Segoe MDL2 Assets)�$��20(�$	����$��10, 5q�$��40��$��50��${�False���� $
��Save��
�������$��Center=��� .+��� -   $ Scan_Btn��$��Segoe MDL2 Assets)�$��20(�$	����$��10, 5q�$��40��$��50���� $
��Scan��
�������$��Center=��� .+��� -   $ 
Upload_Btn��$��Segoe MDL2 Assets)�$��20(�$	����$��10, 5q�${�False��$��40��$��50���� $��Upload document��
�������$��Center=�� -   $��
errorPopup��$��Center=�$	��Top=�$	��150��$	��200��$��False��$��	0,117,0,0q�$��Center=�.���� $��Center=�$��Center=�.+��� -   $��errorMessage��
�������$��13(�
���   ��� -   $��Ok��$	��100��$��40���� $��1��.+��� -	   $��previewImage��$
��Left=�$��30,30q�$	��626��$	��344��$ 0.609,0.504&��� .+��� $��
Add To Pdf��$��Center=��� -
   $ AddToPdf��$��Segoe MDL2 Assets)�$��20(�$	����$��40��$��50��${�False��$ 0.346,3.601&��� -   $��	PdfImages��$��2��$��10,30q�.+��� $
��Left=�$��20,30q�$	��100��$	��Top=�$��70��