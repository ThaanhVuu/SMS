namespace qlsv_dang_nhap.srcMVC.model
{
    public class DiemMVC
    {
        // Thuộc tính hiển thị trong ListView
        public int STT { get; set; }
        public int MaSV { get; set; }
        public int MaHP { get; set; }
        //public string KyHieu { get; set; }
        public string TenHocPhan { get; set; }
        public int SoTinChi { get; set; }
        public double DiemThanhPhan { get; set; }
        public double DiemThi { get; set; }
        public double DiemTongKet { get; set; }

        // Thuộc tính tính toán
        public double DiemSo => ConvertDiemToHe4(DiemTongKet);
        public string DiemChu => ConvertDiemToChu(DiemTongKet);

        // Thuộc tính thống kê (static)
        public static double TBCHe4 { get; set; }
        public static double TBCHe10 { get; set; }
        public static int TongTinChiDat { get; set; }
        public static int TongTinChiTatCa { get; set; }
        public static string XepLoaiHe4 { get; set; }
        public static string XepLoaiHe10 { get; set; }

        public static string ConvertDiemToChu(double diem)
        {
            if (diem >= 8.5) return "A";
            if (diem >= 7.0) return "B";
            if (diem >= 5.5) return "C";
            if (diem >= 4.0) return "D";
            return "F";
        }

        public static double ConvertDiemToHe4(double diem)
        {
            if (diem >= 8.5) return 4.0;
            if (diem >= 7.0) return 3.0;
            if (diem >= 5.5) return 2.0;
            if (diem >= 4.0) return 1.0;
            return 0.0;
        }
    }
}