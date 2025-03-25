using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace qlsv_dang_nhap.View
{
    /// <summary>
    /// Interaction logic for view_PhongCTSV.xaml
    /// </summary>
    public partial class view_PhongCTSV : Window
    {
        private SinhvienBLL sinhvien = new SinhvienBLL();
        private DRLBLL drl = new DRLBLL();
        DataTable dtdssv;
        DataTable dtdrl;
        public view_PhongCTSV()
        {
            InitializeComponent();
            LoadSinhvien();
            LoadSinhvienMini();

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
            LoadSinhvien();
        }
        #endregion
        #region QLDRL
        private void LoadSinhvienMini()
        {
            dssvmini.ItemsSource = dtdssv.DefaultView;
        }
        private void selectionDSSVMini(object sender, SelectionChangedEventArgs e)
        {
            var selected = dssvmini.SelectedItem as DataRowView;
            if (selected == null) return;
            try
            {
                txtMasv.Text = selected["MaSV"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi khi chon sinh vien" + ex.Message);
            }
            LoadDRL();
        }

        private void LoadDRL()
        {
            int id = Convert.ToInt32(txtMasv.Text);
            dtdrl = drl.getDRL(id);
            drlsv.ItemsSource = dtdrl.DefaultView;
        }
        #endregion
    }
}
