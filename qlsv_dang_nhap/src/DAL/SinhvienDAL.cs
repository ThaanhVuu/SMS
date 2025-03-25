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
            var adapter = new SQLiteDataAdapter("select * from sinhvien", conn);
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
}