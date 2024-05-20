using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace DBproject.Pages
{
    public class DB
    {
        public SqlConnection con { get; set; }
        public DB()
        {
            string conStr = "Data Source=SQL6032.site4now.net;User ID=db_aa83e2_nadamohamed123001_admin;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con = new SqlConnection(conStr);
        }


    }
}