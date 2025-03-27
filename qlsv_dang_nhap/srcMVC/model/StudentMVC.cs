namespace qlsv_dang_nhap.srcMVC.model
{
    public class StudentMVC
    {
        // Thu?c tính t??ng ?ng v?i các c?t trong b?ng SinhVien
        public string MaSV { get; set; } // Mã sinh viên
        public string HoTen { get; set; } // H? và tên
        public string NgaySinh { get; set; } // Ngày sinh
        public string GioiTinh { get; set; } // Gi?i tính
        public string Nganh { get; set; } // Ngành h?c
        public string Tenlop { get; set; } // Tên l?p
        public string Nguoigiamho { get; set; } // Ng??i giám h?
        // Thu?c tính t?nh ?? l?u tr? MaSV c?a ng??i dùng ??ng nh?p
        public static string loggedInUsername { get; set; }
    }
}