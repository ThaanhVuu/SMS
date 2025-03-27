using System.Data;
using System.Data.SQLite;

public class DRLDAL
{
    public DRLDAL() { }

    string connectionString = "Data Source =sms.db";

    public DataTable getDRLSV(int id)
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            var dt = new DataTable();
            conn.Open();
            var adapter = new SQLiteDataAdapter($"select sv.MaSV, drl.MaHDNK, hd.TenHDNK, drl.DRL from DiemRL drl join Sinhvien sv on drl.MaSv = sv.MaSV join HoatDongNK hd on drl.MaHDNK = hd.Ma_HDNK where sv.MaSV = {id}",conn);
            adapter.Fill(dt);
            return dt;
        }
    }

    public void savechange(DataTable dt)
    {
        using(var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            var adapter = new SQLiteDataAdapter("select * from DiemRL",conn);
            var builder = new SQLiteCommandBuilder(adapter);
            adapter.Update(dt);
        }
    }
}

