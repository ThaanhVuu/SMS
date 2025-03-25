using System.Collections.Generic;
using System.ComponentModel;
using qlsv_dang_nhap.srcMVC.model;
using qlsv_dang_nhap.srcMVC.controller;

namespace qlsv_dang_nhap.srcMVC.view
{
    public class DiemViewMVC : INotifyPropertyChanged
    {
        private List<DiemMVC> _diemList = new List<DiemMVC>();
        private string _maSinhVien;
        private string _xlHe4;
        private string _xlHe10;
        private string _tbcHe4;
        private string _tbcHe10;
        private string _tongTinChi;

        public List<DiemMVC> DiemList
        {
            get => _diemList;
            set { _diemList = value; OnPropertyChanged(nameof(DiemList)); }
        }

        public string MaSinhVien
        {
            get => _maSinhVien;
            set { _maSinhVien = value; OnPropertyChanged(nameof(MaSinhVien)); }
        }

        public string XepLoaiHe4
        {
            get => _xlHe4;
            set { _xlHe4 = value; OnPropertyChanged(nameof(XepLoaiHe4)); }
        }

        public string XepLoaiHe10
        {
            get => _xlHe10;
            set { _xlHe10 = value; OnPropertyChanged(nameof(XepLoaiHe10)); }
        }

        public string TBCHe4
        {
            get => _tbcHe4;
            set { _tbcHe4 = value; OnPropertyChanged(nameof(TBCHe4)); }
        }

        public string TBCHe10
        {
            get => _tbcHe10;
            set { _tbcHe10 = value; OnPropertyChanged(nameof(TBCHe10)); }
        }

        public string TongTinChi
        {
            get => $"{DiemMVC.TongTinChiDat} / {DiemMVC.TongTinChiTatCa}";
            set { _tongTinChi = value; OnPropertyChanged(nameof(TongTinChi)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadDiem(string loggedInUsername)
        {
            // Lấy mã sinh viên từ username
            int maSV = DiemRepositoryMVC.GetStudentIdByUsername(loggedInUsername);
            if (maSV == 0) return;

            //Load lấy danh sách điểm
            DiemList = DiemRepositoryMVC.GetDiemByMaSV(loggedInUsername);

            // Cập nhật thông tin thống kê
            MaSinhVien = maSV.ToString(); // MaSinhVien sẽ được cập nhật tự động khi DiemList được gán
            XepLoaiHe4 = DiemMVC.XepLoaiHe4;
            XepLoaiHe10 = DiemMVC.XepLoaiHe10;
            TBCHe4 = DiemMVC.TBCHe4.ToString("0.00");
            TBCHe10 = DiemMVC.TBCHe10.ToString("0.00");
            OnPropertyChanged(nameof(TongTinChi));
        }
    }
}