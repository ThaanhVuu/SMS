//namespace qlsv_dang_nhap.srcMVC.model
//{
//    public class MonHocMVC
//    {
//        // Thu?c t�nh t??ng ?ng v?i c�c c?t trong b?ng MonHoc
//        public string MaHP { get; set; } // M� h?c ph?n
//        public string TenHP { get; set; } // T�n h?c ph?n
//        public string Sotinchi { get; set; } // S? t�n ch?
//        public string Hocky { get; set; } // H?c k?
//        public string Namhoc { get; set; } // N?m h?c

//        // Constructor m?c ??nh
//        public MonHocMVC()
//        {
//            MaHP = string.Empty;
//            TenHP = string.Empty;
//            Sotinchi = string.Empty;
//            Hocky = string.Empty;
//            Namhoc = string.Empty;
//        }

//        // Constructor v?i tham s? ?? kh?i t?o ??i t??ng
//        public MonHocMVC(string maHP, string tenHP, string sotinchi, string hocky, string namhoc)
//        {
//            MaHP = maHP;
//            TenHP = tenHP;
//            Sotinchi = sotinchi;
//            Hocky = hocky;
//            Namhoc = namhoc;
//        }

//        // Ph??ng th?c ?? hi?n th? th�ng tin m�n h?c
//        public override string ToString()
//        {
//            return $"M� HP: {MaHP}, T�n HP: {TenHP}, S? t�n ch?: {Sotinchi}, H?c k?: {Hocky}, N?m h?c: {Namhoc}";
//        }
//    }
//}