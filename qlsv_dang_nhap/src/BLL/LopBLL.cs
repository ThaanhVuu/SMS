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
        try
        {
            return dal.getLop();
        }
        catch (Exception ex)
        {
            return null;
            throw ex;
        }
    }

    public void saveChange(DataTable dt)
    {
        dal.saveChange(dt);
    }

}