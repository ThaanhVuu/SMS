using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Windows;
using qlsv_dang_nhap.srcMVC.model;

namespace qlsv_dang_nhap.srcMVC.controller
{
    public class DiemRepositoryMVC
    {
        private static string _connectionString = "Data Source=sms.db";

        public static List<DiemMVC> GetDiemByMaSV(string loggedInUsername)
        {
            List<DiemMVC> diemList = new List<DiemMVC>();
            double tongDiemHe4 = 0, tongDiemHe10 = 0;
            int tongTinChiDat = 0, tongTinChiTatCa = 0, stt = 1;

            try
            {
                using (var conn = new SqliteConnection(_connectionString))
                {
                    conn.Open();

                    // Lấy MaSV từ Username
                    int maSV = GetMaSVFromUsername(conn, loggedInUsername);
                    if (maSV == 0) return diemList;

                    // Lấy danh sách điểm
                    var query = @"
                        SELECT 
                            d.MaHP,
                            m.TenHP,
                            m.Sotinchi,
                            d.DiemQT,
                            d.DiemThi,
                            d.DiemTongKet
                        FROM Diem d
                        JOIN MonHoc m ON d.MaHP = m.MaHP
                        WHERE d.MaSV = @MaSV
                        ORDER BY m.Namhoc, m.Hocky, m.TenHP";

                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int tinChi = Convert.ToInt32(reader["Sotinchi"]);
                                double diemTongKet = reader.GetDouble(5);
                                double diemHe4 = DiemMVC.ConvertDiemToHe4(diemTongKet);

                                var diem = new DiemMVC
                                {
                                    STT = stt++,
                                    MaSV = maSV,
                                    MaHP = reader.GetInt32(0),
                                    //KyHieu = reader["KyHieu"]?.ToString() ?? "N/A",
                                    TenHocPhan = reader["TenHP"]?.ToString() ?? "Không có tên",
                                    SoTinChi = tinChi,
                                    DiemThanhPhan = reader.GetDouble(3),
                                    DiemThi = reader.GetDouble(4),
                                    DiemTongKet = diemTongKet
                                };

                                diemList.Add(diem);
                                tongTinChiTatCa += tinChi;

                                if (diemTongKet >= 4.0) // Đạt từ D trở lên
                                {
                                    tongDiemHe4 += diemHe4 * tinChi;
                                    tongDiemHe10 += diemTongKet * tinChi;
                                    tongTinChiDat += tinChi;
                                }
                            }
                        }
                    }

                    // Tính toán thống kê
                    CalculateStatistics(diemList, tongDiemHe4, tongDiemHe10, tongTinChiDat, tongTinChiTatCa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn CSDL: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return diemList;
        }

        private static int GetMaSVFromUsername(SqliteConnection conn, string username)
        {
            var query = "SELECT MaSV FROM User WHERE Username = @Username";
            using (var cmd = new SqliteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public static int GetStudentIdByUsername(string username)
        {
            try
            {
                using (var conn = new SqliteConnection(_connectionString))
                {
                    conn.Open();
                    return GetMaSVFromUsername(conn, username);
                }
            }
            catch
            {
                return 0;
            }
        }

        private static void CalculateStatistics(List<DiemMVC> diemList,
                                              double tongDiemHe4, double tongDiemHe10,
                                              int tongTinChiDat, int tongTinChiTatCa)
        {
            if (tongTinChiDat > 0)
            {
                DiemMVC.TBCHe4 = Math.Round(tongDiemHe4 / tongTinChiDat, 2);
                DiemMVC.TBCHe10 = Math.Round(tongDiemHe10 / tongTinChiDat, 2);
            }

            DiemMVC.TongTinChiDat = tongTinChiDat;
            DiemMVC.TongTinChiTatCa = tongTinChiTatCa;

            DiemMVC.XepLoaiHe4 = GetXepLoai(DiemMVC.TBCHe4, true);
            DiemMVC.XepLoaiHe10 = GetXepLoai(DiemMVC.TBCHe10, false);
        }

        private static string GetXepLoai(double diemTB, bool isHe4)
        {
            if (isHe4)
            {
                if (diemTB >= 3.6) return "Xuất sắc";
                if (diemTB >= 3.2) return "Giỏi";
                if (diemTB >= 2.8) return "Khá";
                if (diemTB >= 2.0) return "Trung bình";
                return "Yếu";
            }
            else
            {
                if (diemTB >= 9.0) return "Xuất sắc";
                if (diemTB >= 8.0) return "Giỏi";
                if (diemTB >= 7.0) return "Khá";
                if (diemTB >= 5.0) return "Trung bình";
                return "Yếu";
            }
        }
    }
}