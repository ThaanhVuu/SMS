﻿using System.Data;
using System.Data.Common;
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
        private LopBLL lop = new LopBLL();
        private HDNKBLL hdnk = new HDNKBLL();
        DataTable dtdssv;
        DataTable dtdrl;
        DataTable dtlopmini;
        DataTable dthdnk;

        public view_PhongCTSV()
        {
            InitializeComponent();
            LoadSinhvien();
            LoadSinhvienMini();
            LoadLop();
            LoadHdnk();
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
        private void SearchEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearchIcon_Click(sender, e);
            }
        }
        #endregion
        #region Sinhvien
        private void LoadSinhvien()
        {
            dtdssv = sinhvien.searchSV(txtSearch.Text);
            dssv.ItemsSource = dtdssv.DefaultView;
        }
        private void drlsv_BeginningEdit2(object sender, DataGridBeginningEditEventArgs e)
        {
            string[] readOnlyColumns = { "Malop", "Tenlop", "CTDT"};
            if (e.Column is DataGridTextColumn textColumn && readOnlyColumns.Contains(textColumn.Header.ToString()))
            {
                e.Cancel = true;
            }
        }

        private void themsinhvien_click(object sender, RoutedEventArgs e)
        {
            sinhvien.savechange(dtdssv);
            MessageBox.Show("Cập nhật dữ liệu thành công");
            LoadSinhvien();
        }
        private void btnSearchIcon_Click(object sender, RoutedEventArgs e)
        {
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
                if (selected["MaSV"] != DBNull.Value) // Kiểm tra giá trị không phải NULL
                {
                    txtMasv.Text = selected["MaSV"].ToString();
                    LoadDRL(); // Chỉ gọi LoadDRL() khi có giá trị hợp lệ
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi khi chon sinh vien: " + ex.Message);
            }
        }
      

        private void LoadDRL()
        {
            int id = Convert.ToInt32(txtMasv.Text);
            dtdrl = drl.getDRL(id);
            drlsv.ItemsSource = dtdrl.DefaultView;
            foreach (var column in drlsv.Columns)
            {
                // Kiểm tra header hoặc Binding path để xác định cột cần ẩn
                if (column.Header.ToString() == "MaSV" )
                {
                    column.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void drlsv_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // Kiểm tra xem đây có phải dòng mới được thêm vào hay không
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataRowView rowView = e.Row.Item as DataRowView;
                if (rowView != null)
                {
                    // Gán giá trị cho cột MaSV tự động
                    rowView["MaSV"] = Convert.ToInt32(txtMasv.Text);
                }
            }
        }
       
        private void saveDSDRL(object sender, RoutedEventArgs e)
        {
            try
            {
                drl.saveChange(dtdrl);
                MessageBox.Show("Cập nhật điểm rèn luyện thành công");
                LoadDRL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật điểm rèn luyện: " + ex.Message);
            }
        }
        #endregion
        #region LOP
        private void LoadLop()
        {
            dtlopmini = lop.getLop();
            dslopmini.ItemsSource = dtlopmini.DefaultView;
        }
        int malop;
        private void drlsv_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            string[] readOnlyColumns = { "MaSV", "Hoten", "Ngaysinh", "Gioitinh", "Nguoigiamho" };
            if (e.Column is DataGridTextColumn textColumn && readOnlyColumns.Contains(textColumn.Header.ToString()))
            {
                e.Cancel = true;
            }
        }
        void selectionlopmini(object sender, SelectionChangedEventArgs e)
        {
            var selected = dslopmini.SelectedItem as DataRowView;
            if (selected == null) return;
            try
            {
                malop = int.Parse(selected["Malop"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn lớp: " + ex.Message);
            }
            var dv = new DataView(dtdssv);
            dv.RowFilter = $"Malop = {malop}";
            dslop.ItemsSource = dv;
            //khi chọn lớp, lấy mã lớp và lọc dữ liệu danh sách sinh viên theo mã lớp
        }
        void capnhatlop(object sender, RoutedEventArgs e)
        {
            try
            {
                sinhvien.getUpdateBangDiem(dtdssv);
                MessageBox.Show("Cập nhật lớp cho sinh viên thành công");
                LoadLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật lớp cho sinh viên thất bại: " + ex.Message);
            }
        }
        #endregion
        #region hdnk
        void LoadHdnk()
        {
            dthdnk = hdnk.getHDNK();
            dshdnk.ItemsSource = dthdnk.DefaultView;
        }
        void hdnkUpdate(object sender, RoutedEventArgs e)
        {
            hdnk.setHDNK(dthdnk);
            LoadHdnk();
            MessageBox.Show("Cập nhật hoạt động ngoại khóa thành công");
        }
        #endregion
    }
}
