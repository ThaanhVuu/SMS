//using System.Collections.Generic;
//using System.ComponentModel;
//using qlsv_dang_nhap.srcMVC.view;
//using qlsv_dang_nhap.srcMVC.model;

//namespace qlsv_dang_nhap.srcMVC.viewmodel
//{
//    public class MonHocViewModel : INotifyPropertyChanged
//    {
//        // Danh s�ch m�n h?c
//        private List<MonHocMVC> _monHocList = new List<MonHocMVC>();

//        // Thu?c t�nh ?? binding danh s�ch m�n h?c
//        public List<MonHocMVC> MonHocList
//        {
//            get => _monHocList;
//            set
//            {
//                _monHocList = value;
//                OnPropertyChanged(nameof(MonHocList));
//            }
//        }

//        // S? ki?n th�ng b�o thay ??i thu?c t�nh
//        public event PropertyChangedEventHandler? PropertyChanged;
//        protected void OnPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        // Ph??ng th?c ?? c?p nh?t danh s�ch m�n h?c
//        public void LoadMonHoc(string loggedInUsername)
//        {
//            MonHocList = MonHocRepositoryMVC.GetMonHocByMaSV(loggedInUsername);
//        }
//    }
//}