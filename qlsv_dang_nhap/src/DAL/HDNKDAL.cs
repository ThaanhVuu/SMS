using System.Data;
using System.Data.SQLite;

public class HDNKDAL
{
    private string connectionString = "Data Source=sms.db";
    public HDNKDAL() { }
    public DataTable layHDNK()
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            var dt = new DataTable();
            var adapter = new SQLiteDataAdapter("select * from HoatDongNK", conn);
            adapter.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["MaHDNK"] };
            return dt;
        }
    }
    public void SaveChangeHDNK(DataTable dt)
    {
        using var conn = new SQLiteConnection(connectionString);
        conn.Open();
        var adapter = new SQLiteDataAdapter("select * from HoatDongNK", conn);
        var builder = new SQLiteCommandBuilder(adapter);
        adapter.Update(dt);
    }
}

