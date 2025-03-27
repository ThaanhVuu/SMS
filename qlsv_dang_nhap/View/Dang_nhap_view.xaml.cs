using Microsoft.Data.Sqlite;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using qlsv_dang_nhap.srcMVC.model;
using qlsv_dang_nhap.srcMVC.controller;

namespace qlsv_dang_nhap.View
{
    public partial class Dang_nhap_view : Window
    {
        private string _connectionString = "Data Source=sms.db";

        public Dang_nhap_view()
        {
            InitializeComponent();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!CheckUsernameExists(username))
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password == username)
            {
                var changePasswordWindow = new Doimatkhau(username);
                changePasswordWindow.ShowDialog();
                return;
            }

            string hashedPassword = HashPassword(password);
            string role = GetUserRole(username, hashedPassword);

            if (role != null)
            {
                OpenRoleSpecificWindow(role);
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CheckUsernameExists(string username)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM User WHERE Username = $username";
                command.Parameters.AddWithValue("$username", username);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        private string GetUserRole(string username, string hashedPassword)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Role FROM User WHERE Username = $username AND Password = $password";
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$password", hashedPassword);
                var result = command.ExecuteScalar();
                return result?.ToString();
            }
        }

        private void OpenRoleSpecificWindow(string role)
        {
            string username = txtUser.Text;
            StudentMVC.loggedInUsername = username;
            switch (role)
            {
                
                case "Admin":
                    new view_Admin().Show();
                    break;
                case "Phòng CTSV":
                    new view_PhongCTSV().Show();
                    break;
                case "Giảng viên":
                    new view_Giaovien().Show();
                    break;
                case "Sinh viên":
                    new viewTrang_chinh().Show();
                    break;
                default:
                    MessageBox.Show("Role không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
