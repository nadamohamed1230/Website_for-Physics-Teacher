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
            string conStr = "Data Source=SQL6032.site4now.net;Initial Catalog=db_aa83e2_nadamohamed123001;Persist Security Info=True;User ID=db_aa83e2_nadamohamed123001_admin;Password=***********;Trust Server Certificate=True";
            con = new SqlConnection(conStr);
        }


    }
}