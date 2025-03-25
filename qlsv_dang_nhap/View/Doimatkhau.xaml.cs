using Microsoft.Data.Sqlite;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace qlsv_dang_nhap.View
{
    public partial class Doimatkhau : Window
    {
        private string _username;
        private string _connectionString = "Data Source=sms.db"; 

        public Doimatkhau(string username)
        {
            InitializeComponent();
            _username = username;
            txtUsername.Text = _username;
        }

        //btn_Đổi mật khẩu
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = txtOldPassword.Password; 
            string newPassword = txtNewPassword.Password; 
            string confirmPassword = txtConfirmPassword.Password; 

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!CheckOldPassword(_username, oldPassword))
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (UpdatePassword(_username, newPassword))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Kiểm tra mật khẩu cũ 
        private bool CheckOldPassword(string username, string oldPassword)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT Password FROM User
                    WHERE Username = $username";
                command.Parameters.AddWithValue("$username", username);

                string storedPassword = command.ExecuteScalar()?.ToString();
                if (storedPassword == oldPassword) 
                {
                    return true;
                }
                else 
                {
                    string oldPasswordHash = HashPassword(oldPassword);
                    return (oldPasswordHash == storedPassword);
                }
            }
        }

        // Cập nhật mật khẩu mới vào CSDL
        private bool UpdatePassword(string username, string newPassword)
        {
            string newPasswordHash = HashPassword(newPassword);

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var updateCommand = connection.CreateCommand();
                updateCommand.CommandText = @"
                    UPDATE User
                    SET Password = $passwordHash
                    WHERE Username = $username";
                updateCommand.Parameters.AddWithValue("$passwordHash", newPasswordHash);
                updateCommand.Parameters.AddWithValue("$username", username);

                int rowsAffected = updateCommand.ExecuteNonQuery();
                return rowsAffected > 0; 
            }
        }

        // SHA256
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}