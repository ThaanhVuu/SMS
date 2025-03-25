using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace qlsv_dang_nhap.View
{
    public partial class view_Admin : Window
    {
        private string _connectionString = "Data Source=sms.db";

        public view_Admin()
        {
            InitializeComponent();
            LoadData();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void AddUser(string username, string role, int? maSV)
        {
            string passwordHash = HashPassword(username);

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO User (Username, Password, Role, MaSV)
                    VALUES ($username, $password, $role, $maSV)";
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$password", passwordHash);
                command.Parameters.AddWithValue("$role", role);
                command.Parameters.AddWithValue("$maSV", maSV.HasValue ? (object)maSV.Value : DBNull.Value);
                command.ExecuteNonQuery();
            }
            LoadData();
        }

        private void DeleteUser(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM User WHERE ID = $id";
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
            LoadData();
        }

        private void UpdateUser(int id, string username, string role, int? maSV)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    UPDATE User
                    SET Username = $username, Role = $role, MaSV = $maSV
                    WHERE ID = $id";
                command.Parameters.AddWithValue("$username", username);
                command.Parameters.AddWithValue("$role", role);
                command.Parameters.AddWithValue("$maSV", maSV.HasValue ? (object)maSV.Value : DBNull.Value);
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
            LoadData();
        }

        private void LoadData()
        {
            var users = new List<User>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ID, Username, Role, Password, MaSV FROM User";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int? maSV = reader.IsDBNull(4) ? null : reader.GetInt32(4);

                        users.Add(new User
                        {
                            ID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Role = reader.GetString(2),
                            Password = reader.GetString(3),
                            MaSV = maSV
                        });
                    }
                }
            }

            listView.ItemsSource = users;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem is User selectedUser)
            {
                usernameTextBox.Text = selectedUser.Username;
                roleComboBox.Text = selectedUser.Role;
            }
        }

        private void ClearInputs()
        {
            usernameTextBox.Clear();
            roleComboBox.SelectedIndex = -1;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usernameTextBox.Text) && !string.IsNullOrWhiteSpace(roleComboBox.Text))
            {
                AddUser(usernameTextBox.Text, roleComboBox.Text, null);
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem is User selectedUser)
            {
                DeleteUser(selectedUser.ID);
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem is User selectedUser && !string.IsNullOrWhiteSpace(usernameTextBox.Text) && !string.IsNullOrWhiteSpace(roleComboBox.Text))
            {
                UpdateUser(selectedUser.ID, usernameTextBox.Text, roleComboBox.Text, null);
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người dùng và nhập đầy đủ thông tin.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? MaSV { get; set; }
    }
}
