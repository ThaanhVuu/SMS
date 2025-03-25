//using System;
//using Microsoft.Data.Sqlite;
//using System.Windows;
//using System.Configuration;
//using qlsv_dang_nhap.srcMVC.view;
//using qlsv_dang_nhap.srcMVC.model;

//namespace qlsv_dang_nhap.srcMVC.controller
//{
//    public class StudentRepositoryMVC
//    {
//        private string _connectionString = "Data Source=sms.db";

//        // Ph??ng th?c l?y MaSV t? b?ng User d?a trên Username
//        private static string GetMaSVByUsername(string username)
//        {
//            string maSV = null;
//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
//                {
//                    conn.Open();
//                    string query = "SELECT MaSV FROM User WHERE Username = @Username";
//                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@Username", username);
//                        object result = cmd.ExecuteScalar();
//                        if (result != null)
//                        {
//                            maSV = Convert.ToInt32(result); // Chuy?n ??i sang ki?u int
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"L?i truy v?n CSDL: {ex.Message}");
//            }
//            return maSV;
//        }

//        // Phuong thuc lay thông tin sinh viên tu bang SinhVien dua trên MaSV
//        internal static StudentMVC GetStudentById(string loggedInUsername)
//        {
//            StudentMVC student = null;

//            // L?y MaSV t? b?ng User
//            string maSV = GetMaSVByUsername(loggedInUsername);
//            if (string.IsNullOrEmpty(maSV))
//            {
//                MessageBox.Show("Không tìm thay MaSV tuong ung voi Username.");
//                return null;
//            }

//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
//                {
//                    conn.Open();
//                    string query = @"
//                        SELECT 
//                            SinhVien.MaSV, 
//                            SinhVien.Hoten, 
//                            SinhVien.Ngaysinh, 
//                            SinhVien.Gioitinh, 
//                            SinhVien.Tenlop, 
//                            SinhVien.Nganh
//                        FROM SinhVien 
//                        INNER JOIN Lop ON SinhVien.Malop = Lop.Malop 
//                        WHERE SinhVien.MaSV = @MaSV";
//                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@MaSV", maSV);
//                        using (SQLiteDataReader reader = cmd.ExecuteReader())
//                        {
//                            if (reader.Read())
//                            {
//                                student = new StudentMVC
//                                {
//                                    MaSV = reader["MaSV"]?.ToString(),
//                                    HoTen = reader["Hoten"]?.ToString(),
//                                    NgaySinh = DateTime.TryParse(reader["Ngaysinh"]?.ToString(), out DateTime ngaySinh)
//                                        ? ngaySinh.ToString("yyyy/MM/dd")
//                                        : null,
//                                    GioiTinh = reader["Gioitinh"]?.ToString(),
//                                    Nganh = reader["Nganh"]?.ToString(),
//                                    Lop = reader["Tenlop"]?.ToString(),
//                                    Nguoigiamho = reader["Nguoigiamho"]?.ToString()
//                                };
//                            }
//                            else
//                            {
//                                throw new Exception($"Không tìm th?y sinh viên v?i MaSV = {maSV}");
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"L?i truy v?n CSDL: {ex.Message}");
//                return null;
//            }
//            return student;
//        }
//    }
//}