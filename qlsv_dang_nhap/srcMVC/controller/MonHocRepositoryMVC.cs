using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Windows;
using qlsv_dang_nhap.srcMVC.model;

namespace qlsv_dang_nhap.srcMVC.controller
{
    public static class MonHocRepositoryMVC
    {
        private const string ConnectionString = "Data Source=sms.db";

        public static List<MonHocMVC> GetMonHocByMaSV(string username)
        {
            var monHocList = new List<MonHocMVC>();
            int stt = 1;

            try
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();
                    var maSV = GetMaSVFromUsername(connection, username);

                    if (maSV <= 0) return monHocList;

                    const string query = @"
                        SELECT MonHoc.MaHP, MonHoc.TenHP, MonHoc.Sotinchi, MonHoc.Hocky, MonHoc.Namhoc
                        FROM Diem
                        JOIN MonHoc ON Diem.MaHP = MonHoc.MaHP
                        WHERE Diem.MaSV = @MaSV
                        ORDER BY MonHoc.Namhoc, MonHoc.Hocky, MonHoc.TenHP";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSV", maSV);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                monHocList.Add(new MonHocMVC
                                {
                                    STT = stt++,
                                    MaHP = reader["MaHP"].ToString(),
                                    TenHP = reader["TenHP"].ToString(),
                                    SoTinChi = Convert.ToInt32(reader["Sotinchi"]),
                                    Hocky = reader["Hocky"].ToString(),
                                    Namhoc = reader["Namhoc"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải môn học: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return monHocList;
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