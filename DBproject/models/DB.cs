using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                        NID = Convert.ToInt32(reader["nID"]),
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

        public TAs GetAssistantById(int id)
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
                            NID = Convert.ToInt32(reader["nID"]),
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
        public int NID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string FullName => $"{FName} {LName}";
    }


