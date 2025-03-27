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
using System.Windows;
using System.Windows.Controls;
using qlsv_dang_nhap.srcMVC.view;
using qlsv_dang_nhap.srcMVC.model;

namespace qlsv_dang_nhap.userControl
{
    public partial class MH_control : UserControl
    {
        public MonHocViewMVC ViewModel { get; }

        public MH_control()
        {
            InitializeComponent();
            ViewModel = new MonHocViewMVC();
            DataContext = ViewModel;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var username = StudentMVC.loggedInUsername;

                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Vui lòng đăng nhập để xem môn học",
                        "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                ViewModel.LoadMonHoc(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}