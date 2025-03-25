//namespace qlsv_dang_nhap.srcMVC.model
//{
//    public class MonHocMVC
//    {
//        // Thu?c tính t??ng ?ng v?i các c?t trong b?ng MonHoc
//        public string MaHP { get; set; } // Mã h?c ph?n
//        public string TenHP { get; set; } // Tên h?c ph?n
//        public string Sotinchi { get; set; } // S? tín ch?
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

//        // Ph??ng th?c ?? hi?n th? thông tin môn h?c
//        public override string ToString()
//        {
//            return $"Mã HP: {MaHP}, Tên HP: {TenHP}, S? tín ch?: {Sotinchi}, H?c k?: {Hocky}, N?m h?c: {Namhoc}";
//        }
//    }
//}