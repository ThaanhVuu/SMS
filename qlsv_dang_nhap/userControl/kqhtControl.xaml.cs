using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using qlsv_dang_nhap.srcMVC.view;
using qlsv_dang_nhap.srcMVC.model;
using qlsv_dang_nhap.srcMVC.controller;

namespace qlsv_dang_nhap.userControl
{
    /// <summary>
    /// Interaction logic for kqhtControl.xaml
    /// </summary>
    public partial class kqhtControl : UserControl
    {
        public DiemViewMVC DiemViewMVC { get; private set; }

        public kqhtControl()
        {
            InitializeComponent();
            try
            {
                // Lấy thông tin username đã đăng nhập
                string loggedInUsername = StudentMVC.loggedInUsername;

                if (string.IsNullOrEmpty(loggedInUsername))
                {
                    MessageBox.Show("Vui lòng đăng nhập để xem kết quả học tập", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                // Khởi tạo ViewModel và load dữ liệu
                DiemViewMVC = new DiemViewMVC();
                DiemViewMVC.LoadDiem(loggedInUsername);

                // Gán DataContext
                DataContext = DiemViewMVC;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải kết quả học tập: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}