//namespace qlsv_dang_nhap.srcMVC.model
//{
//    public class DiemMVC
//    {
//        // Thu?c tính t??ng ?ng v?i các c?t trong b?ng Diem
//        public string MaSV { get; set; } // Mã sinh viên
//        public string MaHP { get; set; } // Mã h?c ph?n
//        public double DiemQT { get; set; } // ?i?m quá trình
//        public double DiemThi { get; set; } // ?i?m thi
//        public double DiemTongKet { get; set; } // ?i?m t?ng k?t

//        // Thu?c tính tính toán: ?i?m ch?
//        public string DiemChu
//        {
//            get
//            {
//                if (DiemTongKet >= 8.5) return "A";
//                else if (DiemTongKet >= 7.0) return "B";
//                else if (DiemTongKet >= 5.5) return "C";
//                else if (DiemTongKet >= 4.0) return "D";
//                else return "F";
//            }
//        }

//        // Thu?c tính tính toán: ?i?m s? (h? 4)
//        public double DiemSo
//        {
//            get
//            {
//                switch (DiemChu)
//                {
//                    case "A": return 4.0;
//                    case "B": return 3.0;
//                    case "C": return 2.0;
//                    case "D": return 1.0;
//                    default: return 0.0; // F ho?c các tr??ng h?p khác
//                }
//            }
//        }

//        // Constructor m?c ??nh
//        public DiemMVC()
//        {
//            MaSV = string.Empty;
//            MaHP = string.Empty;
//            DiemQT = 0;
//            DiemThi = 0;
//            DiemTongKet = 0;
//        }

//        // Constructor v?i tham s? ?? kh?i t?o ??i t??ng
//        public DiemMVC(string maSV, string maHP, double diemQT, double diemThi, double diemTongKet)
//        {
//            MaSV = maSV;
//            MaHP = maHP;
//            DiemQT = diemQT;
//            DiemThi = diemThi;
//            DiemTongKet = diemTongKet;
//        }

//        // Ph??ng th?c ?? hi?n th? thông tin ?i?m
//        public override string ToString()
//        {
//            return $"Mã SV: {MaSV}, Mã HP: {MaHP}, ?i?m QT: {DiemQT}, ?i?m Thi: {DiemThi}, ?i?m TK: {DiemTongKet}, ?i?m Ch?: {DiemChu}, ?i?m S?: {DiemSo}";
//        }
//    }
//}