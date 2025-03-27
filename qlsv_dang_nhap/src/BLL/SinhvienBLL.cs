using System.Data;

public class SinhvienBLL
{
    SinhvienDAL dal;
    public SinhvienBLL() { dal = new SinhvienDAL(); }
    public DataTable getSinhvien()
    {
        return dal.getSinhvien();
    }
    public void savechange(DataTable dt)
    {
        dal.saveChange(dt);
    }

    public DataTable searchSV(string key)
    {
        return dal.SearchSinhvien(key);
    }

    public DataTable getSinhvienByMalopByMaMH(int malop, int mamh)
    {
        try
        {
            return dal.getSinhvienbyLopMonHoc(malop, mamh);            
        }
        catch
        {
            return null;
            throw new Exception();
        }
    }
    public void getUpdateBangDiem(DataTable dt)
    {
        dal.UpdateDiem(dt);
    }
}