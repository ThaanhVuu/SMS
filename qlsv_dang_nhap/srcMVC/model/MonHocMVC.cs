using System.ComponentModel;

namespace qlsv_dang_nhap.srcMVC.model
{
    public class MonHocMVC : INotifyPropertyChanged
    {
        private int _stt;
        private string _maHP;
        private string _tenHP;
        private int _soTinChi;
        private string _hocky;
        private string _namhoc;

        public int STT
        {
            get => _stt;
            set { _stt = value; OnPropertyChanged(nameof(STT)); }
        }

        public string MaHP
        {
            get => _maHP;
            set { _maHP = value; OnPropertyChanged(nameof(MaHP)); }
        }

        public string TenHP
        {
            get => _tenHP;
            set { _tenHP = value; OnPropertyChanged(nameof(TenHP)); }
        }

        public int SoTinChi
        {
            get => _soTinChi;
            set { _soTinChi = value; OnPropertyChanged(nameof(SoTinChi)); }
        }

        public string Hocky
        {
            get => _hocky;
            set { _hocky = value; OnPropertyChanged(nameof(Hocky)); }
        }

        public string Namhoc
        {
            get => _namhoc;
            set { _namhoc = value; OnPropertyChanged(nameof(Namhoc)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}