using System.Data;

public class LopBLL
{
    LopDAL dal;
    public LopBLL()
    {
        dal = new LopDAL();
    }

    public DataTable getLop()
    {
        return dal.getLop();
    }

    public void saveChange(DataTable dt)
    {
        dal.saveChange(dt);
    }

}