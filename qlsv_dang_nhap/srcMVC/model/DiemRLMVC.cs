using System.ComponentModel;

namespace qlsv_dang_nhap.srcMVC.model
{
    public class DiemRLMVC : INotifyPropertyChanged
    {
        private int _stt;
        private int _maHDNK;
        private string _tenHDNK;
        private int _drl;
        private string _xepLoai;

        public int STT
        {
            get => _stt;
            set { _stt = value; OnPropertyChanged(nameof(STT)); }
        }

        public int MaHDNK
        {
            get => _maHDNK;
            set { _maHDNK = value; OnPropertyChanged(nameof(MaHDNK)); }
        }

        public string TenHDNK
        {
            get => _tenHDNK;
            set { _tenHDNK = value; OnPropertyChanged(nameof(TenHDNK)); }
        }

        public int DRL
        {
            get => _drl;
            set
            {
                _drl = value;
                OnPropertyChanged(nameof(DRL));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}