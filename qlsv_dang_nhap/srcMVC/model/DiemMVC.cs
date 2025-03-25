//namespace qlsv_dang_nhap.srcMVC.model
//{
//    public class DiemMVC
//    {
//        // Thu?c t�nh t??ng ?ng v?i c�c c?t trong b?ng Diem
//        public string MaSV { get; set; } // M� sinh vi�n
//        public string MaHP { get; set; } // M� h?c ph?n
//        public double DiemQT { get; set; } // ?i?m qu� tr�nh
//        public double DiemThi { get; set; } // ?i?m thi
//        public double DiemTongKet { get; set; } // ?i?m t?ng k?t

//        // Thu?c t�nh t�nh to�n: ?i?m ch?
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

//        // Thu?c t�nh t�nh to�n: ?i?m s? (h? 4)
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
//                    default: return 0.0; // F ho?c c�c tr??ng h?p kh�c
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

//        // Ph??ng th?c ?? hi?n th? th�ng tin ?i?m
//        public override string ToString()
//        {
//            return $"M� SV: {MaSV}, M� HP: {MaHP}, ?i?m QT: {DiemQT}, ?i?m Thi: {DiemThi}, ?i?m TK: {DiemTongKet}, ?i?m Ch?: {DiemChu}, ?i?m S?: {DiemSo}";
//        }
//    }
//}