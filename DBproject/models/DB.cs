using System.Collections.Generic;
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

        public void addquiz( int id,long t_id, string tobic, int quecount, int ac_year, int level)
        {
            string query = "insert into Quizzes (Quiz_id,T_ID,tobic,quecount,ac_year,hardnesslevel)values(" + id + "," + t_id + "," + "'" + tobic + "'" + "," + quecount + "," + ac_year + "," + level + ")";
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

        public int idquiz()
        {
            int id = new int();
            string query = "select max(Quiz_id) from Quizzes ";
            try
            {
             
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                 id=(int) cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return id;

        }

        public void quizQuestion(int count,int Quiz_id,int ac_year,int hard)
        {
            string query =" INSERT INTO QuizcontainQuestions(Q_ID, Quiz_id) SELECT top "+ count+"(Q_ID),"+ Quiz_id + "FROM( SELECT Q_ID, ROW_NUMBER()" +
                " OVER(ORDER BY Q_ID) AS row_num FROM Questions WHERE AC_year =" + ac_year + " AND level_ = " + hard + ") AS sub";
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