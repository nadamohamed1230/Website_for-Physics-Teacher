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
            string conStr = "Data Source=Silverstone;Initial Catalog=Survey;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            con = new SqlConnection(conStr);
        }

    }
}
