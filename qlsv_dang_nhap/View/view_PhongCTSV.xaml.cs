using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace qlsv_dang_nhap.View
{
    /// <summary>
    /// Interaction logic for view_PhongCTSV.xaml
    /// </summary>
    public partial class view_PhongCTSV : Window
    {
        private SinhvienBLL sinhvien = new SinhvienBLL();
        DataTable dtdssv;
        public view_PhongCTSV()
        {
            InitializeComponent();
            LoadSinhvien();
        }
        #region setsearch
        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholder.Visibility = Visibility.Collapsed;
        }
        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtPlaceholder.Visibility = Visibility.Visible;
            }
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPlaceholder.Visibility = string.IsNullOrEmpty(txtSearch.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void btnSearchIcon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng tìm kiếm chưa được triển khai.");
        }
        private void SearchEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearchIcon_Click(sender, new RoutedEventArgs());
            }
        }
        #endregion
        #region Sinhvien
        private void LoadSinhvien()
        {
            dtdssv = sinhvien.getSinhvien();
            dssv.ItemsSource = dtdssv.DefaultView;
        }

        private void themsinhvien_click(object sender, RoutedEventArgs e)
        {
            sinhvien.savechange(dtdssv);
            MessageBox.Show("Cập nhật dữ liệu thành công");
        }
        #endregion
    }
}
