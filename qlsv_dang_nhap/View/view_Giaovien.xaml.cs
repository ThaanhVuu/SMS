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
        void LoadMonhoc() {
            dtmonhoc = monhoc.abc();
            monhocmini.ItemsSource = dtmonhoc.DefaultView;
        }
        
        int malop = 0, mahp = 0;
        void lopselection(object sender, SelectionChangedEventArgs e)
        {
            var selected = dslopmini.SelectedItem as DataRowView;
            malop = Convert.ToInt32(selected["Malop".ToString()]);
            LoadMonhoc();
        }
        void monhocselection(object sender, SelectionChangedEventArgs e)
        {
            var selected = monhocmini.SelectedItem as DataRowView;
            mahp = Convert.ToInt32(selected["MaHP".ToString()]);
            LoadSinhvien();
        }

        void LoadSinhvien()
        {
            dtsv = sv.getSinhvienByMalopByMaMH(malop, mahp);
            dssv.ItemsSource = dtsv.DefaultView;
        }
    }
}
