   M S B A M L   `   `   `  ����I  Eqlsv_dang_nhap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:qlsv_dang_nhap.userControlqlsv_dang_nhap.userControl  5      ,    &qlsv_dang_nhap.userControl.Drl_Control   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:qlsv_dang_nhap.userControl     5      .��5	      � .+�5
   
   �� 
�������._�5      �   � RowDefinitions  5      �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   .+�5      �� $��Điểm rèn luyện: ��6    $
��Bold"�68   $��14(�6J   $��15,0,0,0q�5       �� 5      
���  ��$��14(�5      $��10,0,0,0q�5       ��5       �� *
TongDiemRL+ �� StringFormat$ {0} điểm��5       5      �� 5      $��1��6   $'��!Các hoạt động đã tham gia��5      $
��Bold"�6=   $��15,0,0,0q�5      $��Bottom=�6.   �� 5      $��2��6   
�������$��1q�69    �� Padding$ 5q�6M   $��10q�6Y   ._�5      �� -   5        $��BangDiemListView��5   B   ��6   �� *
DiemRLList+ �� View 5      �� 5      .P�5    "   �� $	��STT��61    �� Width$
 auto��6>    �� DisplayMemberBinding 6K   �� *STT+�� 5!   "   $&�� Mã Hoạt động ngoại khóa��61   $
 auto��6R    6_   �� *MaHDNK+�� 5"   "   $'��!Tên Hoạt động ngoại khóa��61   $
 auto��6S    6`   �� *	TenHDNK+�� 5#   "   $��Điểm rèn luyện��61   $
 auto��6I    6V   �� *DRL+5$      5&      5'      5)      5*      5,      5-      