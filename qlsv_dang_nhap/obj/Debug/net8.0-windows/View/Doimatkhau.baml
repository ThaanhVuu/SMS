   M S B A M L   `   `   `  ����I  Eqlsv_dang_nhap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:qlsv_dang_nhap.Viewqlsv_dang_nhap.View  5   	   $    qlsv_dang_nhap.View.Doimatkhau   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:qlsv_dang_nhap.View     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Đổi mật khẩu��5	   	   $	��300��6   $	��350��6+   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6V   .+�5      �� $��	Username:��6   $��5q�6)   $
��Bold"�64   �� 5      -   5         ��Name$ txtUsername��5      $��5q�6>   
���  ����6-   �� 6I   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6V   .+�5      �� $��Mật khẩu cũ:��6   $��5q�6,   $
��Bold"�67   G� 5      -   5         G�Name$ txtOldPassword��5      $	��150��62   $��45,3,3,3q�6>   $��12(�6P   5      �� 5    
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6V   .+�5!      �� $��Mật khẩu mới:��6   $��5q�6-   $
��Bold"�68   G� 5"      -   5        $ txtNewPassword��5"      $	��150��62   $��36,3,3,3q�6>   $��12(�6P   5#      �� 5&   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6V   .+�5'      �� $��Xác nhận mật khẩu:��6   $��5q�62   $
��Bold"�6=   G� 5(      -   5        $ txtConfirmPassword��5(      $	��150��66   $��8,3,3,3q�6B   $��12(�6S   5)      �� 5,   
   -   5         ��Name$ btnChangePassword��5,      $��4��6   $��Đổi mật khẩu��69   $	��100��5-      $��30��6   $
��Bold"�6)   $��10q�6;   5.      5/      50      