using System.Collections.Generic;
using System.ComponentModel;
using qlsv_dang_nhap.srcMVC.model;
using qlsv_dang_nhap.srcMVC.controller;

namespace qlsv_dang_nhap.srcMVC.view
{
    public class MonHocViewMVC : INotifyPropertyChanged
    {
        private List<MonHocMVC> _monHocList = new List<MonHocMVC>();

        public List<MonHocMVC> MonHocList
        {
            get => _monHocList;
            set
            {
                _monHocList = value;
                OnPropertyChanged(nameof(MonHocList));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadMonHoc(string username)
        {
            MonHocList = MonHocRepositoryMVC.GetMonHocByMaSV(username);
        }
    }
}