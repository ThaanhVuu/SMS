//using System.Collections.Generic;
//using System.ComponentModel;
//using qlsv_dang_nhap.srcMVC.view;
//using qlsv_dang_nhap.srcMVC.model;

//namespace qlsv_dang_nhap.srcMVC.view
//{
//    public class DiemViewMVC : INotifyPropertyChanged
//    {
//        // Danh sách ?i?m
//        private List<DiemMVC> _diemList = new List<DiemMVC>();

//        // Thu?c tính ?? binding danh sách ?i?m
//        public List<DiemMVC> DiemList
//        {
//            get => _diemList;
//            set
//            {
//                _diemList = value;
//                OnPropertyChanged(nameof(DiemList));
//            }
//        }

//        // S? ki?n thông báo thay ??i thu?c tính
//        public event PropertyChangedEventHandler? PropertyChanged;
//        protected void OnPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        // Ph??ng th?c ?? c?p nh?t danh sách ?i?m
//        public void LoadDiem(string loggedInUsername)
//        {
//            DiemList = DiemRepositoryMVC.GetDiemByMaSV(loggedInUsername);
//        }
//    }
//}