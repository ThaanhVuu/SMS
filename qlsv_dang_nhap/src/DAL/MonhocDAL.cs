using System.Data;
using System.Data.SQLite;

public class MonhocDAL
{
    public MonhocDAL() { }
    string connection = "Data Source =sms.db";
    public DataTable getMonhoc()
    {
        var dt = new DataTable();
        using (var conn = new SQLiteConnection(connection))
        {
            conn.Open();
            var adapter = new SQLiteDataAdapter("select * from monhoc",conn);
            adapter.Fill(dt);
            return dt;
        }
    }
}