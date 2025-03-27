using System.Data;

public class MonhocBLL
{
    MonhocDAL dal;
    public MonhocBLL()
    {
        dal = new MonhocDAL();
    }
    public DataTable abc()
    {
        try
        {
            var dt = new DataTable();
            dt = dal.getMonhoc();
            return dt;
        }
        catch
        {
            return null;
            throw new Exception();
        }
    }
}