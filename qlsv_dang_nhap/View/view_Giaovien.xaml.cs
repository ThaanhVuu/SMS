using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace qlsv_dang_nhap.View
{
    /// <summary>
    /// Interaction logic for view_Giaovien.xaml
    /// </summary>
    public partial class view_Giaovien : Window
    {
        DataTable dtlop = new DataTable();
        LopBLL lop = new LopBLL();
        SinhvienBLL sv = new SinhvienBLL();
        MonhocBLL monhoc = new MonhocBLL();
        DataTable dtsv = new DataTable();
        DataTable dtmonhoc = new DataTable();
        public view_Giaovien()
        {
            InitializeComponent();
            LoadLop();
            LoadMonhoc();
        }
        void LoadLop()
        {
            dtlop = lop.getLop();
            dslopmini.ItemsSource = dtlop.DefaultView;
        }
        void LoadMonhoc()
        {
            dtmonhoc = monhoc.abc();
            monhocmini.ItemsSource = dtmonhoc.DefaultView;
        }

        int malop = 0, mahp = 0;
        void lopselection(object sender, SelectionChangedEventArgs e)
        {
            var selected = dslopmini.SelectedItem as DataRowView;
            malop = Convert.ToInt32(selected["Malop".ToString()]);
            if (malop != 0 && mahp != 0)
            {
                LoadSinhvien(malop, mahp);
            }
        }
        void monhocselection(object sender, SelectionChangedEventArgs e)
        {
            var selected = monhocmini.SelectedItem as DataRowView;
            mahp = Convert.ToInt32(selected["MaHP".ToString()]);
            if (malop != 0 && mahp != 0)
            {
                LoadSinhvien(malop, mahp);
            }
        }
        void LoadSinhvien(int Malop, int mahp)
        {
            dtsv = sv.getSinhvienByMalopByMaMH(Malop, mahp);
            dssv.ItemsSource = dtsv.DefaultView;
        }
        void luubttn(object sender, RoutedEventArgs e)
        {
            try
            {
                sv.getUpdateBangDiem(dtsv);
                LoadSinhvien(malop, mahp);
            }
            //catch (DBConcurrencyException ex)
            //{
            //    MessageBox.Show("Lỗi khi cập nhật điểm cho sinh viên: chỉ có thể cập nhật điểm thi và điểm tổng kết.");
            //}
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
