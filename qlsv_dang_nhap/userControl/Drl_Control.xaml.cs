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
    public partial class Drl_Control : UserControl
    {
        public DiemRLViewMVC ViewModel { get; }

        public Drl_Control()
        {
            InitializeComponent();
            ViewModel = new DiemRLViewMVC();
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
                    MessageBox.Show("Vui lòng đăng nhập để xem điểm rèn luyện",
                        "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                ViewModel.LoadDiemRL(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
