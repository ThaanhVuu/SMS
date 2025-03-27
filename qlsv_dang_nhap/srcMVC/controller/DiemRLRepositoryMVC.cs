using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Windows;
using qlsv_dang_nhap.srcMVC.model;

namespace qlsv_dang_nhap.srcMVC.controller
{
    public static class DiemRLRepositoryMVC
    {
        private const string ConnectionString = "Data Source=sms.db";

        public static List<DiemRLMVC> GetDiemRLByUsername(string username)
        {
            var diemRLList = new List<DiemRLMVC>();
            int stt = 1;

            try
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    var maSV = GetMaSVFromUsername(connection, username);

                    if (maSV <= 0) return diemRLList;

                    const string query = @"
                        SELECT h.Ma_HDNK, h.TenHDNK, d.DRL
                        FROM DiemRL d
                        JOIN HoatDongNK h ON d.MaHDNK = h.Ma_HDNK
                        WHERE d.MaSV = @MaSV
                        ORDER BY h.TenHDNK";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSV", maSV);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                diemRLList.Add(new DiemRLMVC
                                {
                                    STT = stt++,
                                    MaHDNK = Convert.ToInt32(reader["Ma_HDNK"]),
                                    TenHDNK = reader["TenHDNK"].ToString(),
                                    DRL = Convert.ToInt32(reader["DRL"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải điểm rèn luyện: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return diemRLList;
        }

        private static int GetMaSVFromUsername(SqliteConnection connection, string username)
        {
            const string query = "SELECT MaSV FROM User WHERE Username = @Username";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                var result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}