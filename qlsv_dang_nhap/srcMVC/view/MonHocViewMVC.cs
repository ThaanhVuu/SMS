//using System.Collections.Generic;
//using System.ComponentModel;
//using qlsv_dang_nhap.srcMVC.view;
//using qlsv_dang_nhap.srcMVC.model;

//namespace qlsv_dang_nhap.srcMVC.viewmodel
//{
//    public class MonHocViewModel : INotifyPropertyChanged
//    {
//        // Danh sách môn h?c
//        private List<MonHocMVC> _monHocList = new List<MonHocMVC>();

//        // Thu?c tính ?? binding danh sách môn h?c
//        public List<MonHocMVC> MonHocList
//        {
//            get => _monHocList;
//            set
//            {
//                _monHocList = value;
//                OnPropertyChanged(nameof(MonHocList));
//            }
//        }

//        // S? ki?n thông báo thay ??i thu?c tính
//        public event PropertyChangedEventHandler? PropertyChanged;
//        protected void OnPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        // Ph??ng th?c ?? c?p nh?t danh sách môn h?c
//        public void LoadMonHoc(string loggedInUsername)
//        {
//            MonHocList = MonHocRepositoryMVC.GetMonHocByMaSV(loggedInUsername);
//        }
//    }
//}