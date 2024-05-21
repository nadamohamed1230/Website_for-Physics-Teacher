using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DBproject.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
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
            {
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
            }

            return user;
        }

        public async Task RegisterUserAsync(User user)
        {
            string query = "INSERT INTO Student (Fname, Lname, nID, pnum, mail, ac_year, pay_state, TnID, password)" +
                           "VALUES (@FirstName, @LastName, @ID, @ParentNumber, @Email, @AcademicYear, @PayState, @TnID, @Password)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
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
        }
        public async Task UpdateUserPasswordAsync(long id, string newPassword)
        {
            string query = "UPDATE [dbo].[User] SET password = @Password WHERE nID = @ID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
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
        }
        public async Task UpdateUserEmailAsync(long id, string newemail)
        {
            string query = "UPDATE [dbo].[User] SET mail = @Email WHERE nID = @ID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Email", newemail);

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
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync( long username, string password)
        {
            return await Users.FirstOrDefaultAsync(u => u.ID == username && u.Password == password);
        }
    }


}
