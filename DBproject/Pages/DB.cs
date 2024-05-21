using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DBproject.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;

namespace DBproject.Pages
{
    public class DB
    {
        private readonly string _connectionString;
        public DbSet<User> Users { get; set; }

        public DB()
        {
            _connectionString = "Data Source=SQL6032.site4now.net; Initial Catalog=db_aa83e2_nadamohamed123001;User ID=db_aa83e2_nadamohamed123001_admin;Password=_123456_789_NDAY";
        }

        public async Task<User?> ValidateUserAsync(long id, string password, string role)
        {
            User? user = null;
            string query = role switch
            {
                "student" => "SELECT * FROM [dbo].[Student] WHERE nID = @ID AND password = @Password",
                "parent" => "SELECT * FROM [dbo].[Parent] WHERE nID = @ID AND password = @Password",
                "teacher" => "SELECT * FROM [dbo].[Teacher] WHERE nID = @ID AND password = @Password",
                "assistant" => "SELECT * FROM [dbo].[Assistant] WHERE nID = @ID AND password = @Password",
                _ => throw new ArgumentException("Invalid user role")
            };

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            user = new User
                            {
                                ID = Convert.ToInt64(reader["nID"]),
                                Password = reader["password"].ToString(),
                                Role = role,
                                FirstName = reader["Fname"].ToString(),
                                LastName = reader["Lname"].ToString(),
                                Email = reader["mail"].ToString(),
                                AcademicYear = role == "student" ? Convert.ToInt32(reader["ac_year"]) : 0
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error while validating user: " + ex.Message);
                }
            }

            return user;
        }

        public async Task RegisterUserAsync(User user)
        {
            string query = "INSERT INTO Student (Fname, Lname, nID, pnum, mail, ac_year, pay_state, TnID, password)" +
                           "VALUES (@FirstName, @LastName, @ID, @ParentNumber, @Email, @AcademicYear, @PayState, @TnID, @Password)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@ParentNumber", user.ParentNumber);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@AcademicYear", user.AcademicYear);
                cmd.Parameters.AddWithValue("@PayState", user.PayState);
                cmd.Parameters.AddWithValue("@TnID", user.TnID);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                try
                {
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error while registering user: " + ex.Message);
                }
            }
        }

        public async Task UpdateUserPasswordAsync(long id, string newPassword)
        {
            string query = "UPDATE [dbo].[User] SET password = @Password WHERE nID = @ID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Password", newPassword);

                try
                {
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error while updating user password: " + ex.Message);
                }
            }
        }

        public async Task UpdateUserEmailAsync(long id, string newEmail)
        {
            string query = "UPDATE [dbo].[User] SET mail = @Email WHERE nID = @ID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Email", newEmail);

                try
                {
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error while updating user email: " + ex.Message);
                }
            }
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(long username, string password)
        {
            return await Users.FirstOrDefaultAsync(u => u.ID == username && u.Password == password);
        }

        public async Task AddQuestionsAsync(string chapter, int level, int acYear, long tId, string question, string optionA, string optionB, string optionC, string optionD, string correctAnswer)
        {
            string query = "INSERT INTO Questions (chapter, level_, AC_year, T_ID, Question, option_A, option_B, option_C, option_D, CorrectAnswers) " +
                           "VALUES (@Chapter, @Level, @AcYear, @TId, @Question, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectAnswer)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Chapter", chapter);
                cmd.Parameters.AddWithValue("@Level", level);
                cmd.Parameters.AddWithValue("@AcYear", acYear);
                cmd.Parameters.AddWithValue("@TId", tId);
                cmd.Parameters.AddWithValue("@Question", question);
                cmd.Parameters.AddWithValue("@OptionA", optionA);
                cmd.Parameters.AddWithValue("@OptionB", optionB);
                cmd.Parameters.AddWithValue("@OptionC", optionC);
                cmd.Parameters.AddWithValue("@OptionD", optionD);
                cmd.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);

                try
                {
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error while adding question: " + ex.Message);
                }
            }
        }

        public async Task AddAssistantAsync(string nid, string fname, string lname, string phone, string password)
        {
            string query = "INSERT INTO Assistant (nID, Fname, Lname, pnum, password) VALUES (@NID, @Fname, @Lname, @Phone, @Password)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@NID", nid);
                cmd.Parameters.AddWithValue("@Fname", fname);
                cmd.Parameters.AddWithValue("@Lname", lname);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error while adding assistant: " + ex.Message);
                }
            }
        }





        public void AddQuestions(string chapter, int level, int academicYear, long teacherId, string question, string optionA, string optionB, string optionC, string optionD, string correctAnswer)
        {
            string query = "INSERT INTO Questions (chapter, level_, AC_year, T_ID, Question, option_A, option_B, option_C, option_D, CorrectAnswers) " +
                           "VALUES (@Chapter, @Level, @AcademicYear, @TeacherId, @Question, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectAnswer)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Chapter", chapter);
                    cmd.Parameters.AddWithValue("@Level", level);
                    cmd.Parameters.AddWithValue("@AcademicYear", academicYear);
                    cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                    cmd.Parameters.AddWithValue("@Question", question);
                    cmd.Parameters.AddWithValue("@OptionA", optionA);
                    cmd.Parameters.AddWithValue("@OptionB", optionB);
                    cmd.Parameters.AddWithValue("@OptionC", optionC);
                    cmd.Parameters.AddWithValue("@OptionD", optionD);
                    cmd.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);

                    try
                    {
                        con.Open();
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

        public void AddAssistant(string nid, string firstName, string lastName, string phone, string password)
        {
            string query = "INSERT INTO Assistant (nID, Fname, Lname, pnum, password) VALUES (@NID, @FirstName, @LastName, @Phone, @Password)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", nid);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        con.Open();
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
        public void UpdateStudentPaymentStatus(string nid, string payState)
        {
            // Validate parameters
            if (string.IsNullOrEmpty(nid))
            {
                throw new ArgumentException("Student ID cannot be null or empty.", nameof(nid));
            }

            if (string.IsNullOrEmpty(payState))
            {
                throw new ArgumentException("Payment state cannot be null or empty.", nameof(payState));
            }

            string query = "UPDATE Student SET pay_state = @PayState WHERE nID = @NID";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NID", nid);
                        cmd.Parameters.AddWithValue("@PayState", payState);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating student payment status: " + ex.Message);
                // Consider rethrowing or handling the exception appropriately
            }
        }


        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT nID, Fname, Lname, pnum, mail, ac_year, pay_state FROM Student";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
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

            return students;
        }

        public void UpdateAssistant(TAs assistant)
        {
            string query = "UPDATE Assistant SET Fname = @Fname, Lname = @Lname, pnum = @Phone WHERE nID = @NID";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating assistant: " + ex.Message);
                throw;
            }
        }

        public void AddVideo(string videoUrl, int acYear, string chapter, string title, long tId)
        {
            string multimediaQuery = "INSERT INTO MultiMedia (ac_year, Chapter, title, T_ID) OUTPUT INSERTED.M_ID VALUES (@AcYear, @Chapter, @Title, @TId)";
            string videoQuery = "INSERT INTO Videos (video_url, M_ID) VALUES (@VideoUrl, @MId)";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    int insertedId;
                    using (SqlCommand cmd = new SqlCommand(multimediaQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@AcYear", acYear);
                        cmd.Parameters.AddWithValue("@Chapter", chapter);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@TId", tId);

                        insertedId = (int)cmd.ExecuteScalar();
                    }

                    if (insertedId > 0)
                    {
                        using (SqlCommand videoCmd = new SqlCommand(videoQuery, con))
                        {
                            videoCmd.Parameters.AddWithValue("@VideoUrl", videoUrl);
                            videoCmd.Parameters.AddWithValue("@MId", insertedId);
                            videoCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to insert multimedia record.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding video: " + ex.Message);
                throw;
            }
        }

        public int InsertMultimediaRecord(int acYear, string chapter, string title, long tId)
        {
            string multimediaQuery = "INSERT INTO MultiMedia (ac_year, Chapter, title, T_ID) OUTPUT INSERTED.M_ID VALUES (@AcYear, @Chapter, @Title, @TId)";
            int insertedId;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
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
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(pdfQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@PdfUrl", pdfUrl);
                        cmd.Parameters.AddWithValue("@MultimediaId", multimediaId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting PDF record: " + ex.Message);
                throw;
            }
        }
        public TAs GetAssistantById(long id)
        {
            // Validate parameter
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            TAs assistant = null;
            string query = "SELECT nID, Fname, Lname, pnum FROM Assistant WHERE nID = @NID";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting assistant by ID: " + ex.Message);
                // Consider rethrowing or handling the exception appropriately
            }

            return assistant;
        }

        public void DeleteTA(long id)
        {
            // Validate parameter
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            string query = "DELETE FROM Assistant WHERE nID = @NID";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting TA: " + ex.Message);
                // Consider rethrowing or handling the exception appropriately
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
        public void QuizQuestion(int count, int quizId, int academicYear, int hardnessLevel)
        {
            // Validate parameters
            if (count <= 0)
            {
                throw new ArgumentException("Count must be greater than zero.", nameof(count));
            }

            if (quizId <= 0)
            {
                throw new ArgumentException("Quiz ID must be greater than zero.", nameof(quizId));
            }

            if (academicYear <= 0)
            {
                throw new ArgumentException("Academic year must be greater than zero.", nameof(academicYear));
            }

            if (hardnessLevel <= 0)
            {
                throw new ArgumentException("Hardness level must be greater than zero.", nameof(hardnessLevel));
            }

            string query = "INSERT INTO QuizcontainQuestions (Q_ID, Quiz_id) SELECT TOP (@Count) Q_ID, @QuizId FROM (SELECT Q_ID, ROW_NUMBER() OVER (ORDER BY Q_ID) AS row_num FROM Questions WHERE AC_year = @AcademicYear AND level_ = @HardnessLevel) AS sub";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Count", count);
                        cmd.Parameters.AddWithValue("@QuizId", quizId);
                        cmd.Parameters.AddWithValue("@AcademicYear", academicYear);
                        cmd.Parameters.AddWithValue("@HardnessLevel", hardnessLevel);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding quiz questions: " + ex.Message);
                // Consider rethrowing or handling the exception appropriately
            }
        }
        public List<TAs> GetAssistants()
        {
            List<TAs> assistants = new List<TAs>();
            string query = "SELECT nID, Fname, Lname, pnum FROM Assistant";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // You might want to handle or log the exception more appropriately
            }

            return assistants;
        }


        public void AddQuiz(int id, long t_id, string topic, int queCount, int ac_year, int level)
        {
            // Validate parameters
            if (id <= 0)
            {
                throw new ArgumentException("Quiz ID must be greater than zero.", nameof(id));
            }

            if (t_id <= 0)
            {
                throw new ArgumentException("Teacher ID must be greater than zero.", nameof(t_id));
            }

            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentException("Topic cannot be null or empty.", nameof(topic));
            }

            if (queCount <= 0)
            {
                throw new ArgumentException("Question count must be greater than zero.", nameof(queCount));
            }

            if (ac_year <= 0)
            {
                throw new ArgumentException("Academic year must be greater than zero.", nameof(ac_year));
            }

            if (level <= 0)
            {
                throw new ArgumentException("Hardness level must be greater than zero.", nameof(level));
            }

            string query = "INSERT INTO Quizzes (Quiz_id, T_ID, tobic, quecount, ac_year, hardnesslevel) VALUES (@Id, @TeacherId, @Topic, @QueCount, @AcYear, @Level)";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@TeacherId", t_id);
                        cmd.Parameters.AddWithValue("@Topic", topic);
                        cmd.Parameters.AddWithValue("@QueCount", queCount);
                        cmd.Parameters.AddWithValue("@AcYear", ac_year);
                        cmd.Parameters.AddWithValue("@Level", level);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding quiz: " + ex.Message);
                // Consider rethrowing or handling the exception appropriately
            }
        }

        public int quizid()
        {
            int id = 0;
            string query = "SELECT MAX(Quiz_id) FROM Quizzes";
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            id = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting max Quiz_id: " + ex.Message);
                // Consider rethrowing or handling the exception appropriately
            }
            return id;
        }


        public List<QuizStudent> GetStudentQuizzes(long studentId)
        {
            List<QuizStudent> quizzes = new List<QuizStudent>();
            string query = "SELECT Q_ID, grade FROM quizzstudent WHERE snID = @StudentId";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", studentId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            quizzes.Add(new QuizStudent
                            {
                                Q_ID = Convert.ToInt32(reader["Q_ID"]),
                                Grade = Convert.ToInt32(reader["grade"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return quizzes;
        }

        public void UpdateStudentInDatabase(Student student)
        {
            string query = "UPDATE Student SET Fname = @Fname, Lname = @Lname, pnum = @Phone, mail = @Mail, ac_year = @AcYear, pay_state = @PayState WHERE nID = @NID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
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
                    Console.WriteLine("Error updating student: " + ex.Message);
                    throw;
                }
            }
        }

        public Student GetStudentById(string nid)
        {
            Student student = null;
            string query = "SELECT nID, Fname, Lname, pnum, mail, ac_year, pay_state FROM Student WHERE nID = @NID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NID", nid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching student with ID " + nid + ": " + ex.Message);
                    throw;
                }
            }

            return student;
        }
        public DataTable GetQuizGrades(long id)
        {
            DataTable grades = new DataTable();
            string query = "SELECT Quizzes.tobic, QuizzStudent.grade, Quizzes.quecount " +
                           "FROM QuizzStudent " +
                           "JOIN Quizzes ON QuizzStudent.Q_ID = Quizzes.Quiz_id " +
                           "WHERE snid = @ID";

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        grades.Load(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // You might want to handle or log the exception more appropriately
            }

            return grades;
        }

        public void DeleteStudent(string nid)
        {
            string query = "DELETE FROM Student WHERE nID = @NID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NID", nid);

                    try
                    {
                        con.Open();
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
   


      
   

    }
    public class TAs
    {
        public long NID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string FullName => $"{FName} {LName}";
    }
    public class QuizStudent
    {
        public int Q_ID { get; set; }
        public int Grade { get; set; }
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
}