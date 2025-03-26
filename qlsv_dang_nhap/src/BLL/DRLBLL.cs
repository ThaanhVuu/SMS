using System.Data;

public class DRLBLL
{
    DRLDAL dal;
    public DRLBLL() {
        dal = new DRLDAL();
    }
    public DataTable getDRL(int id)
    {
        return dal.getDRLSV(id);
    } 
    public void saveChange(DataTable dt)
    {
        dal.savechange(dt);
    }
}

