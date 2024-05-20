using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace DBproject.models
{
    public class DB
    {
        public SqlConnection con { get; set; }
        public DB()
        {
            string conStr = "Data Source=SQL6032.site4now.net; Initial Catalog=db_aa83e2_nadamohamed123001;User ID=db_aa83e2_nadamohamed123001_admin;Password=_123456_789_NDAY";
            con = new SqlConnection(conStr);
        }

        public void addquestions(string ch, int level, int ac_year, long t_id, string que, string otionA, string otionB, string otionC, string otionD, string correct)
        {
            string query = "insert into Questions(chapter, level_,AC_year,T_ID,Question,option_A,option_B,option_C,option_D ,CorrectAnswers) Values(" +
               "'" + ch + "'" + "," + level + "," + ac_year + "," + t_id + "," + "'" + que + "'" + "," + "'" + otionA + "'" + "," + "'" + otionB + "'" + "," + "'" + otionC + "'" + "," + "'" + otionD + "'" + "," + "'" + correct + "'" + ")";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

    }
}