   M S B A M L   `   `   `  ����I  Eqlsv_dang_nhap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:qlsv_dang_nhap.Viewqlsv_dang_nhap.View  5   	   '    !qlsv_dang_nhap.View.view_Giaovien   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:qlsv_dang_nhap.View     5   	     � Title$  view_Giaovien��5   	   $	��600��6   $	��900��6,   .��5	      �� ._�5
      �� $��16(�6   
�������.@�5      �� ��5      �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $+��%/Images/icon_admin/icons8-book-50.png��6$   $��16��5       $��16��6+   �� 5      $��Quản lý điểm��6(   $��16(�5      $��Arial)�6'   $
��Bold"�6:   5      .��5      �  � ColumnDefinitions 5      �� 5      $	��250 �6/   �� 5      $��* �6/   .+�5      �� $��0��6   
�������$��0,0,2,0q�6E   ._�5      �  � RowDefinitions 5   "   �� 5   &   $	��220 �64   �� 5   &   $	��220 �64   �� 5   &   $��* �64   .+�5!   "   �� $��0��6)   ._�5"   &   �� -   5         ��Name$ 	dslopmini��5"   /   $��Stretch=�6b   $��Stretch=�5#   +   $	��200��6G   $	��200��6S    �� View 5$   *   �� 5%   .   .P�5&   2   �� $��Lớp��6A    �� Width$ 0��6N    �� DisplayMemberBinding 6Y   �� *Malop+�� 5'   .   $��Lớp��6=   $
 Auto��6J    6X   �� *Tenlop+5(   +   5*   '   5+   #   �� 5,      $��1��6%   ._�5-   "   �� -   5        $ 
monhocmini��5-   +   $��Stretch=�6b   $��Stretch=�5.   +   $	��200��6G   $	��200��6S    5/   &   �� 50   *   .P�51   .   �� $��
Môn học��6=   $ 0��6N    6Y   �� *MaHP+�� 52   .   $��
Môn học��6=   $
 Auto��6N    6\   �� *TenHP+53   +   55   #   56      �� 57      $��2��6%   ._�58   "   �� .+�59   &   �� -   5        $��30��5:   )   $	��150��65   $
��Lưu��5;   -   $��14(�6;   $
��Bold"�6I   $��0,10,0,0q�5<   -   5=   #   5>      5?      5@      �� 5A      $��1��6   ._�5B      &   System.Windows.Controls.DataGrid  -   5          Name$
 dssv��5B   #   	   AutoGenerateColumns$
	 True��61   
   
IsReadOnly$
 False��6L   5C      5D      5E      5F      5G      5H      