using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using DBproject.Models;

namespace DBproject.Pages
{
    public class DB
    {
        public SqlConnection con { get; set; }
        public DB()
        {
            string conStr = "Data Source=SQL6032.site4now.net;Initial Catalog=db_aa83e2_nadamohamed123001;Persist Security Info=True;User ID=db_aa83e2_nadamohamed123001_admin;Password=_123456_789_NDAY";
            con = new SqlConnection(conStr);
        }


        public void RegisterUser(User user)
        {
            string query = "INSERT INTO Student (Fname, Lname, nID, pnum, mail, ac_year, pay_state, TnID , password)" +
                           "VALUES (@FirstName, @LastName,@ID,@ParentNumber, @Email, @AcademicYear,@PayState, @Password , @TnID)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@ParentNumber", user.ParentNumber);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@AcademicYear", user.AcademicYear);
                cmd.Parameters.AddWithValue("@PayState", "inactive");
                cmd.Parameters.AddWithValue("@TnID", "27805190300771");
                cmd.Parameters.AddWithValue("@Password", user.Password);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public User ValidateUser(int id, string password, string role)
        {
            User user = null;
            string query;
            switch (role)
            {
                case "student":
                    query = "SELECT * FROM [dbo].[Student] WHERE nID = @ID AND password = @Password";
                    break;
                case "parent":
                    query = "SELECT * FROM [dbo].[Parent] WHERE nID = @ID AND password = @Password";
                    break;
                case "teacher":
                    query = "SELECT * FROM [dbo].[Teacher] WHERE nID = @ID AND password = @Password";
                    break;
                case "assistant":
                    query = "SELECT * FROM [dbo].[Assistant] WHERE nID = @ID AND password = @Password";
                    break;
                default:
                    throw new ArgumentException("Invalid user role");
            }

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {

                            ID = Convert.ToInt32(reader["nID"]), // Replace "ID" with the corresponding column name
                            Password = (string)reader["password"], // Replace "Password" with the corresponding column name
                            Role = role,
                            FirstName = (string)reader["Fname"], // Replace "FirstName" with the corresponding column name
                            LastName = (string)reader["Lname"], // Replace "LastName" with the corresponding column name
                            Email = (string)reader["mail"], // Replace "Email" with the corresponding column name
                        };
                    }

                    return user;
                }

            }
        }
    }
}
