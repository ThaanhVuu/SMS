using System;
using Microsoft.Data.Sqlite;
using System.Windows;
using System.Configuration;
using qlsv_dang_nhap.srcMVC.view;
using qlsv_dang_nhap.srcMVC.model;

namespace qlsv_dang_nhap.srcMVC.controller
{
    public class StudentRepositoryMVC
    {
        private static string _connectionString = "Data Source=sms.db";

        // Phương thức lấy MaSV từ bảng User dựa trên Username
        public static string GetMaSVByUsername(string username)
        {
            string maSV = null;
            try
            {
                using (var conn = new SqliteConnection(_connectionString))
                {
                    conn.Open();
                    var query = "SELECT MaSV FROM User WHERE Username = @Username";
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        var result = cmd.ExecuteScalar();
                        return result?.ToString(); // Sử dụng toán tử null-conditional
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn CSDL: {ex.Message}");
            }
            return maSV;
        }

        // Phương thức lấy thông tin sinh viên từ bảng SinhVien dựa trên MaSV
        public static StudentMVC GetStudentById(string loggedInUsername)
        {
            StudentMVC student = null;
            // Lấy MaSV từ bảng User
            string maSV = GetMaSVByUsername(loggedInUsername);
            //if (string.IsNullOrEmpty(maSV))
            //{
            //    MessageBox.Show("Không tìm thấy MaSV tương ứng với Username.");
            //    return null;
            //}

            try
            {
                using (var conn = new SqliteConnection(_connectionString))
                {
                    conn.Open();
                    var query = @"
                        SELECT 
                            SinhVien.MaSV, 
                            SinhVien.Hoten, 
                            SinhVien.Ngaysinh, 
                            SinhVien.Gioitinh, 
                            Lop.Tenlop, 
                            Lop.CTDT,
                            SinhVien.Nguoigiamho
                        FROM SinhVien 
                        INNER JOIN Lop ON SinhVien.Malop = Lop.Malop 
                        WHERE SinhVien.MaSV = @MaSV";
                    using (var cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                student = new StudentMVC
                                {
                                    MaSV = reader["MaSV"]?.ToString(),
                                    HoTen = reader["Hoten"]?.ToString(),
                                    NgaySinh = DateTime.TryParse(reader["Ngaysinh"]?.ToString(), out DateTime ngaySinh)
                                        ? ngaySinh.ToString("yyyy/MM/dd")
                                        : null,
                                    GioiTinh = reader["Gioitinh"]?.ToString(),
                                    Nganh = reader["CTDT"]?.ToString(),
                                    Tenlop = reader["Tenlop"]?.ToString(),
                                    Nguoigiamho = reader["Nguoigiamho"]?.ToString()
                                };
                            }
                            else
                            {
                                throw new Exception($"Không tìm thấy sinh viên với MaSV = {maSV}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn CSDL: {ex.Message}");
                return null;
            }
            return student;
        }
    }
}