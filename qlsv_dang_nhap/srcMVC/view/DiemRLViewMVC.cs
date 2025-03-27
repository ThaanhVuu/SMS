using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using qlsv_dang_nhap.srcMVC.model;
using qlsv_dang_nhap.srcMVC.controller;

namespace qlsv_dang_nhap.srcMVC.view
{
    public class DiemRLViewMVC : INotifyPropertyChanged
    {
        private List<DiemRLMVC> _diemRLList = new List<DiemRLMVC>();
        private string _maSinhVien;
        private int _tongDiemRL;

        public List<DiemRLMVC> DiemRLList
        {
            get => _diemRLList;
            set
            {
                _diemRLList = value;
                CalculateTongDiemRL(); // Tính toán tổng điểm khi dữ liệu thay đổi
                OnPropertyChanged(nameof(DiemRLList));
            }
        }

        public string MaSinhVien
        {
            get => _maSinhVien;
            set { _maSinhVien = value; OnPropertyChanged(nameof(MaSinhVien)); }
        }

        public int TongDiemRL
        {
            get => _tongDiemRL;
            set { _tongDiemRL = value; OnPropertyChanged(nameof(TongDiemRL)); }
        }

        private void CalculateTongDiemRL()
        {
            TongDiemRL = DiemRLList.Sum(d => d.DRL);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadDiemRL(string username)
        {
            DiemRLList = DiemRLRepositoryMVC.GetDiemRLByUsername(username);
            MaSinhVien = username;
        }
    }
}