using System.Data;
using System.Data.SQLite;

public class SinhvienDAL
{
    string connectionString = "Data Source =sms.db";
    public SinhvienDAL() { }
    public DataTable getSinhvien()
    {
        using (var conn = new SQLiteConnection(connectionString))
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
            SELECT sv.*, l.Tenlop, l.CTDT FROM Sinhvien sv
            join lop l on l.malop = sv.malop
            WHERE 
                CAST(sv.MaSV AS TEXT) LIKE @search 
                OR CAST(l.Malop AS TEXT) LIKE @search 
                OR l.Tenlop LIKE @search 
                OR l.CTDT LIKE @search 
                OR sv.Hoten LIKE @search 
                OR sv.Gioitinh LIKE @search 
                OR sv.Nguoigiamho LIKE @search";

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

    public DataTable getSinhvienbyLopMonHoc(int malop, int mahp)
    {
        var dt = new DataTable();
        using (var conn = new SQLiteConnection(connectionString))
        {
            // Thêm d.MaHP và sửa alias diemtong thành DiemTongKet
            string query = $@"
        SELECT 
            d.MaHP,
            sv.masv, 
            sv.hoten, 
            d.DiemQT, 
            d.DiemThi, 
            (d.DiemQT * 0.4 + d.DiemThi * 0.6) AS DiemTongKet 
        FROM diem d 
        JOIN sinhvien sv ON sv.MaSV = d.MaSV 
        JOIN monhoc mh ON mh.MaHP = d.MaHP 
        JOIN lop l ON l.Malop = sv.Malop 
        WHERE l.Malop = {malop} 
          AND mh.MaHP = {mahp};";

            var adapter = new SQLiteDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }
    }

    public void UpdateDiem(DataTable dt)
    {
        using (var conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string updateSql = "UPDATE diem SET DiemQT = @DiemQT, DiemThi = @DiemThi WHERE MaSV = @MaSV AND MaHP = @MaHP";
            using (SQLiteCommand updateCommand = new SQLiteCommand(updateSql, conn))
            {
                updateCommand.Parameters.Add("@DiemQT", DbType.Double, 0, "DiemQT");
                updateCommand.Parameters.Add("@DiemThi", DbType.Double, 0, "DiemThi");
                updateCommand.Parameters.Add("@MaSV", DbType.Int32, 0, "masv"); // Kiểm tra tên cột trong DataTable
                updateCommand.Parameters.Add("@MaHP", DbType.Int32, 0, "MaHP");

                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                adapter.UpdateCommand = updateCommand;
                adapter.Update(dt);
            }
        }
    }
}
