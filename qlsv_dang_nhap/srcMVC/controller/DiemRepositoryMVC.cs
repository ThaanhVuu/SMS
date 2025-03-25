//using System;
//using System.Collections.Generic;
//using Microsoft.Data.Sqlite;
//using System.Windows;
//using System.Configuration;
//using qlsv_dang_nhap.srcMVC.view;
//using qlsv_dang_nhap.srcMVC.model;

//namespace qlsv_dang_nhap.srcMVC.controller
//{
//    public class DiemRepositoryMVC
//    {
//        private static string connectionString = ConfigurationManager.ConnectionStrings["sms"].ConnectionString;

//        // Ph??ng th?c l?y danh sách ?i?m c?a sinh viên d?a trên MaSV
//        internal static List<DiemMVC> GetDiemByMaSV(string loggedInUsername)
//        {
//            List<DiemMVC> diemList = new List<DiemMVC>();

//            // L?y MaSV t? b?ng User
//            int maSV = StudentRepositoryMVC.GetMaSVByUsername(loggedInUsername);
//            if (maSV == -1)
//            {
//                MessageBox.Show("Không tìm th?y MaSV t??ng ?ng v?i Username.");
//                return diemList;
//            }

//            try
//            {
//                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
//                {
//                    conn.Open();
//                    string query = @"
//                        SELECT 
//                            Diem.MaSV, 
//                            Diem.MaHP, 
//                            Diem.DiemQT, 
//                            Diem.DiemThi, 
//                            Diem.DiemTongKet
//                        FROM Diem
//                        WHERE Diem.MaSV = @MaSV";
//                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@MaSV", maSV);
//                        using (SQLiteDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                DiemMVC diem = new DiemMVC
//                                {
//                                    MaSV = reader["MaSV"]?.ToString(),
//                                    MaHP = reader["MaHP"]?.ToString(),
//                                    DiemQT = Convert.ToDouble(reader["DiemQT"]),
//                                    DiemThi = Convert.ToDouble(reader["DiemThi"]),
//                                    DiemTongKet = Convert.ToDouble(reader["DiemTongKet"])
//                                };
//                                diemList.Add(diem);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"L?i truy v?n CSDL: {ex.Message}");
//            }
//            return diemList;
//        }
//    }
//}