namespace qlsv_dang_nhap.srcMVC.model
{
    public class StudentMVC
    {
        // Thu?c t�nh t??ng ?ng v?i c�c c?t trong b?ng SinhVien
        public string MaSV { get; set; } // M� sinh vi�n
        public string HoTen { get; set; } // H? v� t�n
        public string NgaySinh { get; set; } // Ng�y sinh
        public string GioiTinh { get; set; } // Gi?i t�nh
        public string Nganh { get; set; } // Ng�nh h?c
        public string Tenlop { get; set; } // T�n l?p
        public string Nguoigiamho { get; set; } // Ng??i gi�m h?
        // Thu?c t�nh t?nh ?? l?u tr? MaSV c?a ng??i d�ng ??ng nh?p
        public static string loggedInUsername { get; set; }
    }
}