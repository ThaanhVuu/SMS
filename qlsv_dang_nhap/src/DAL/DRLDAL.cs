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
            var adapter = new SQLiteDataAdapter($"select drl.MaSV, drl.MaHDNK, hdnk.TenHDNK, drl.DRL from DiemRL drl join Sinhvien sv on sv.MaSV = drl.MaSV join HoatDongNK hdnk on hdnk.Ma_HDNK = drl.MaHDNK where sv.MaSV = {id}", conn);
            adapter.Fill(dt);
            return dt;
        }
    }
    public void saveChange(DataTable dt)
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            var adapter = new SQLiteDataAdapter("SELECT * FROM DiemRL", conn);
            var builder = new SQLiteCommandBuilder(adapter); 
            adapter.Update(dt);
        }
    }
}

