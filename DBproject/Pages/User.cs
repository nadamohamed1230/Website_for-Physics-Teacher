namespace DBproject.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ParentNumber { get; set; }
        public int AcademicYear { get; set; }
        public string PayState { get; set; } = "inactive";
        public string TnID { get; set; } = "27805190300771"; 
    }
}
