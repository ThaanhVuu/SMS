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
}