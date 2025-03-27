using System.ComponentModel;

namespace qlsv_dang_nhap.srcMVC.view
{
    public class StudentViewMVC : INotifyPropertyChanged
    {
        // Các tr??ng d? li?u
        private int _maSV = 0;
        private string _hoTen = string.Empty;
        private string _ngaySinh = string.Empty;
        private string _gioiTinh = string.Empty;
        private string _nganh = string.Empty;
        private string _tenlop = string.Empty;
        private string _nguoigiamho = string.Empty;

        // Thu?c tính t??ng ?ng v?i các tr??ng d? li?u
        public int MaSV
        {
            get => _maSV;
            set { _maSV = value; OnPropertyChanged(nameof(MaSV)); }
        }

        public string HoTen
        {
            get => _hoTen;
            set { _hoTen = value; OnPropertyChanged(nameof(HoTen)); }
        }

        public string NgaySinh
        {
            get => _ngaySinh;
            set { _ngaySinh = value; OnPropertyChanged(nameof(NgaySinh)); }
        }

        public string GioiTinh
        {
            get => _gioiTinh;
            set { _gioiTinh = value; OnPropertyChanged(nameof(GioiTinh)); }
        }

        public string Nganh
        {
            get => _nganh;
            set { _nganh = value; OnPropertyChanged(nameof(Nganh)); }
        }

        public string Tenlop
        {
            get => _tenlop;
            set { _tenlop = value; OnPropertyChanged(nameof(Tenlop)); }
        }

        public string Nguoigiamho
        {
            get => _nguoigiamho;
            set { _nguoigiamho = value; OnPropertyChanged(nameof(Nguoigiamho)); }
        }

        // S? ki?n thông báo thay ??i thu?c tính
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}