using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Security.Cryptography;

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
            string query = "INSERT INTO Questions(chapter, level_,AC_year,T_ID,Question,option_A,option_B,option_C,option_D ,CorrectAnswers) VALUES(" +
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

        public void AddAssistant(string nid, string fname, string lname, string phone, string password)
        {
            string query = "INSERT INTO Assistant (nID, Fname, Lname, pnum, password) VALUES (@NID, @Fname, @Lname, @Phone, @Password)";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", nid);
                    cmd.Parameters.AddWithValue("@Fname", fname);
                    cmd.Parameters.AddWithValue("@Lname", lname);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                }
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

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT nID, Fname, Lname, pnum, mail, ac_year, pay_state FROM Student";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        NId = reader["nID"].ToString(),
                        FName = reader["Fname"].ToString(),
                        LName = reader["Lname"].ToString(),
                        Phone = reader["pnum"].ToString(),
                        Mail = reader["mail"].ToString(),
                        AcYear = reader["ac_year"].ToString(),
                        PayState = reader["pay_state"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return students;
        }

        public void DeleteStudent(string nid)
        {
            string query = "DELETE FROM Student WHERE nID = @NID";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", nid);
                    cmd.ExecuteNonQuery();
                }
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
        public void DeleteTA(long id)
        {
            string query = "DELETE FROM Assistant WHERE nID = @NID";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", id);
                    cmd.ExecuteNonQuery();
                }
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

        public void UpdateStudentPaymentStatus(string nid, string payState)
        {
            string query = "UPDATE Student SET pay_state = @PayState WHERE nID = @NID";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", nid);
                    cmd.Parameters.AddWithValue("@PayState", payState);
                    cmd.ExecuteNonQuery();
                }
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

        public Student GetStudentById(string nid)
        {
            Student student = null;
            string query = "SELECT nID, Fname, Lname, pnum, mail, ac_year, pay_state FROM Student WHERE nID = @NID";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", nid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        student = new Student
                        {
                            NId = reader["nID"].ToString(),
                            FName = reader["Fname"].ToString(),
                            LName = reader["Lname"].ToString(),
                            Phone = reader["pnum"].ToString(),
                            Mail = reader["mail"].ToString(),
                            AcYear = reader["ac_year"].ToString(),
                            PayState = reader["pay_state"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return student;
        }

        public void UpdateStudentInDatabase(Student student)
        {
            string query = "UPDATE Student SET Fname = @Fname, Lname = @Lname, pnum = @Phone, mail = @Mail, ac_year = @AcYear, pay_state = @PayState WHERE nID = @NID";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", student.NId);
                    cmd.Parameters.AddWithValue("@Fname", student.FName);
                    cmd.Parameters.AddWithValue("@Lname", student.LName);
                    cmd.Parameters.AddWithValue("@Phone", student.Phone);
                    cmd.Parameters.AddWithValue("@Mail", student.Mail);
                    cmd.Parameters.AddWithValue("@AcYear", student.AcYear);
                    cmd.Parameters.AddWithValue("@PayState", student.PayState);
                    cmd.ExecuteNonQuery();
                }
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
        public List<TAs> GetAssistants()
        {
            List<TAs> assistants = new List<TAs>();
            string query = "SELECT nID, Fname, Lname, pnum FROM Assistant";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    assistants.Add(new TAs
                    {
                        NID = Convert.ToInt64(reader["nID"]),
                        FName = reader["Fname"].ToString(),
                        LName = reader["Lname"].ToString(),
                        Phone = reader["pnum"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return assistants;

        }

        public void addquiz(int id, long t_id, string tobic, int quecount, int ac_year, int level)
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
                id = (int)cmd.ExecuteScalar();

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

        public void quizQuestion(int count, int Quiz_id, int ac_year, int hard)
        {
            string query = " INSERT INTO QuizcontainQuestions(Q_ID, Quiz_id) SELECT top " + count + "(Q_ID)," + Quiz_id + "FROM( SELECT Q_ID, ROW_NUMBER()" +
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


        public TAs GetAssistantById(long id)
        {
            TAs assistant = null;
            string query = "SELECT nID, Fname, Lname, pnum FROM Assistant WHERE nID = @NID";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        assistant = new TAs
                        {
                            NID = Convert.ToInt64(reader["nID"]),
                            FName = reader["Fname"].ToString(),
                            LName = reader["Lname"].ToString(),
                            Phone = reader["pnum"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return assistant;
        }

        public void UpdateAssistant(TAs assistant)
        {
            string query = "UPDATE Assistant SET Fname = @Fname, Lname = @Lname, pnum = @Phone WHERE nID = @NID";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", assistant.NID);
                    cmd.Parameters.AddWithValue("@Fname", assistant.FName);
                    cmd.Parameters.AddWithValue("@Lname", assistant.LName);
                    cmd.Parameters.AddWithValue("@Phone", assistant.Phone);
                    cmd.ExecuteNonQuery();
                }
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
        //public void AddPdf(string pdfUrl, int acYear, string chapter, string title, long tId)
        //{
        //    string multimediaQuery = "INSERT INTO MultiMedia (ac_year, Chapter, title, T_ID) OUTPUT INSERTED.M_ID VALUES (@AcYear, @Chapter, @Title, @TId)";
        //    string pdfQuery = "INSERT INTO PDFs (pdf_url, M_ID) VALUES (@PdfUrl, @MId)";

        //    try
        //    {

        //        con.Open();

        //        int insertedId;
        //        using (SqlCommand cmd = new SqlCommand(multimediaQuery, con))
        //        {
        //            cmd.Parameters.AddWithValue("@AcYear", acYear);
        //            cmd.Parameters.AddWithValue("@Chapter", chapter);
        //            cmd.Parameters.AddWithValue("@Title", title);
        //            cmd.Parameters.AddWithValue("@TId", tId);

        //            insertedId = (int)cmd.ExecuteScalar();
        //        }

        //        Only execute the PDF insert if the multimedia insert was successful
        //            if (insertedId > 0)
        //        {
        //            using (SqlCommand pdfCmd = new SqlCommand(pdfQuery, con))
        //            {
        //                pdfCmd.Parameters.AddWithValue("@PdfUrl", pdfUrl);
        //                pdfCmd.Parameters.AddWithValue("@MId", insertedId);
        //                pdfCmd.ExecuteNonQuery();
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Failed to insert multimedia record.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //        throw;
        //    }
        //}
        public int InsertMultimediaRecord(int acYear, string chapter, string title, long tId)
        {
            string s = "Data Source=SQL6032.site4now.net; Initial Catalog=db_aa83e2_nadamohamed123001;User ID=db_aa83e2_nadamohamed123001_admin;Password=_123456_789_NDAY";

            string multimediaQuery = "INSERT INTO MultiMedia (ac_year, Chapter, title, T_ID) OUTPUT INSERTED.M_ID VALUES (@AcYear, @Chapter, @Title, @TId)";
            int insertedId;
            try
            {
                using (SqlConnection con = new SqlConnection(s))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(multimediaQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@AcYear", acYear);
                        cmd.Parameters.AddWithValue("@Chapter", chapter);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@TId", tId);

                         insertedId = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting multimedia record: " + ex.Message);
                throw;
            }
            return insertedId;

        }

        public void InsertPdfRecord(string pdfUrl, int multimediaId)
        {
            string pdfQuery = "INSERT INTO PDFs (pdf_url, M_ID) VALUES (@PdfUrl, @MultimediaId)";

            try
            {
                
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(pdfQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@PdfUrl", pdfUrl);
                        cmd.Parameters.AddWithValue("@MultimediaId", multimediaId);
                        cmd.ExecuteNonQuery();
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting PDF record: " + ex.Message);
                throw;
            }
        }
        public void AddPdf(string pdfUrl, int acYear, string chapter, string title, long tId)
        {
            try
            {
                int multimediaId = InsertMultimediaRecord(acYear, chapter, title, tId);
                if (multimediaId > 0)
                {
                    InsertPdfRecord(pdfUrl, multimediaId);
                }
                else
                {
                    throw new Exception("Failed to insert multimedia record.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding PDF: " + ex.Message);
                throw;
            }
        }



    }

}


    public class Student
    {
        public string NId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string AcYear { get; set; }
        public string PayState { get; set; }
        public string FullName => $"{FName} {LName}";
    }
    public class TAs
    {
        public long NID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string FullName => $"{FName} {LName}";
    }


