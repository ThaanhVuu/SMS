//using System;
//using System.Collections.Generic;
//using Microsoft.Data.Sqlite;
//using System.Windows;
//using System.Configuration;
//using qlsv_dang_nhap.srcMVC.view;
//using qlsv_dang_nhap.srcMVC.model;

//namespace qlsv_dang_nhap.srcMVC.controller
//{
//    public class MonHocRepositoryMVC
//    {
//        private static string connectionString = ConfigurationManager.ConnectionStrings["sms"].ConnectionString;

//        // Ph??ng th?c l?y danh sách môn h?c c?a sinh viên d?a trên MaSV
//        internal static List<MonHocMVC> GetMonHocByMaSV(string loggedInUsername)
//        {
//            List<MonHocMVC> monHocList = new List<MonHocMVC>();

//            // L?y MaSV t? b?ng User
//            int maSV = StudentRepositoryMVC.GetMaSVByUsername(loggedInUsername);
//            if (maSV == -1)
//            {
//                MessageBox.Show("Không tìm th?y MaSV t??ng ?ng v?i Username.");
//                return monHocList;
//            }

//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
//                {
//                    conn.Open();
//                    string query = @"
//                        SELECT 
//                            MonHoc.MaHP, 
//                            MonHoc.TenHP, 
//                            MonHoc.Sotinchi, 
//                            MonHoc.Hocky, 
//                            MonHoc.Namhoc
//                        FROM Diem
//                        INNER JOIN MonHoc ON Diem.MaHP = MonHoc.MaHP
//                        WHERE Diem.MaSV = @MaSV";
//                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@MaSV", maSV);
//                        using (SQLiteDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                MonHocMVC monHoc = new MonHocMVC
//                                {
//                                    MaHP = reader["MaHP"]?.ToString(),
//                                    TenHP = reader["TenHP"]?.ToString(),
//                                    Sotinchi = reader["Sotinchi"]?.ToString(),
//                                    Hocky = reader["Hocky"]?.ToString(),
//                                    Namhoc = reader["Namhoc"]?.ToString()
//                                };
//                                monHocList.Add(monHoc);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"L?i truy v?n CSDL: {ex.Message}");
//            }
//            return monHocList;
//        }
//    }
//}