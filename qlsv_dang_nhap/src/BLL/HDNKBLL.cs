
using System.Data;

public class HDNKBLL
{
    HDNKDAL dal;
    public HDNKBLL()
    {
        dal = new HDNKDAL();
    }

    public DataTable getHDNK()
    {
        return dal.layHDNK();
    }

    public void setHDNK(DataTable dt)
    {
        dal.SaveChangeHDNK(dt);
    }
}

