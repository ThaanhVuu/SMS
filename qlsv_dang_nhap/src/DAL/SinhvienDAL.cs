using System.Data;
using System.Data.SQLite;

public class SinhvienDAL
{
    string connectionString = "Data Source =sms.db";
    public SinhvienDAL() { }
    public DataTable getSinhvien()
    {
        using(var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            var dt = new DataTable();
            var adapter = new SQLiteDataAdapter("select sv.*, l.Tenlop, l.CTDT from sinhvien sv join Lop l on sv.Malop = l.Malop", conn);
            adapter.Fill(dt);
            return dt;
        }
    }
    public void saveChange(DataTable dt)
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            var adapter = new SQLiteDataAdapter("select * from sinhvien", conn);
            var builder = new SQLiteCommandBuilder(adapter);
            adapter.Update(dt);
        }
    }

    public DataTable SearchSinhvien(string searchText)
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            var dt = new DataTable();
            conn.Open();
            string query = @"
            SELECT * FROM Sinhvien 
            WHERE 
                CAST(MaSV AS TEXT) LIKE @search 
                OR CAST(Malop AS TEXT) LIKE @search 
                OR Hoten LIKE @search 
                OR Gioitinh LIKE @search 
                OR Nguoigiamho LIKE @search";

            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@search", $"%{searchText}%");
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }

}