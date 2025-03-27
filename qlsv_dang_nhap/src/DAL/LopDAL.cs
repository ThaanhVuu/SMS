using System.Data;
using System.Data.SQLite;

public class LopDAL
{
    string connectionString = "Data Source=sms.db";
    public LopDAL() { }
    public DataTable getLop()
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            var dt = new DataTable();
            conn.Open();
            var adapter = new SQLiteDataAdapter("select * from lop", conn);
            adapter.Fill(dt);
            return dt;
        }
    }
    public void saveChange(DataTable dt)
    {
        using var conn = new SQLiteConnection(connectionString);
        conn.Open();
        var adapter = new SQLiteDataAdapter("select * from lop",conn);
        var builder = new SQLiteCommandBuilder(adapter);
        adapter.Update(dt);
    }

}

