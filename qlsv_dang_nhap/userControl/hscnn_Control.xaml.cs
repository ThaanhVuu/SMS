using System;
using System.Windows;
using System.Windows.Controls;
using qlsv_dang_nhap.srcMVC.view;
using qlsv_dang_nhap.srcMVC.model;

namespace qlsv_dang_nhap.userControl
{
    /// <summary>
    /// Interaction logic for hscnn_Control.xaml
    /// </summary>
    public partial class hscnn_Control : UserControl
    {
        public StudentViewMVC StudentViewMVC { get; private set; }

        public hscnn_Control(StudentMVC student)
        {
            InitializeComponent();
            try
            {
                int maSV = 0;
                int.TryParse(student.MaSV, out maSV);
                StudentViewMVC = new StudentViewMVC
                {
                    MaSV = maSV,
                    HoTen = student.HoTen ?? "",
                    NgaySinh = student.NgaySinh ?? "",
                    GioiTinh = student.GioiTinh ?? "",
                    Nganh = student.Nganh ?? "",
                    Tenlop = student.Tenlop ?? "",
                    Nguoigiamho = student.Nguoigiamho ?? ""
                };
                DataContext = StudentViewMVC;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}