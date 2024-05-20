using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBproject.Models;
using System.Numerics;

namespace DBproject.Pages
{
    public class LoginModel : PageModel
    {
        private readonly DB _db;

        public LoginModel()
        {
            _db = new DB();
        }
        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Role { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User user = _db.ValidateUser(ID, Password, Role);

            if (user != null)
            {
                // Redirect users based on their role and academic year
                switch (user.Role)
                {
                    case "Teacher":
                        return RedirectToPage("/Teacher");
                    case "Assistant":
                        return RedirectToPage("/Assistant");
                    case "Student":
                        // Redirect students based on their academic year
                        switch (user.AcademicYear)
                        {
                            case 1:
                                return RedirectToPage("/S1"); // Replace "StudentYear1" with the actual page name for first-year students.
                            case 2:
                                return RedirectToPage("/S2"); // Replace "StudentYear2" with the actual page name for second-year students.
                            case 3:
                                return RedirectToPage("/S3"); // Replace "StudentYear3" with the actual page name for third-year students.
                            default:
                                // Handle unknown academic years
                                return RedirectToPage("/Error"); // Redirect to an error page or handle it as appropriate.
                        }
                    case "Parent":
                        return RedirectToPage("/Parent");
                    default:
                        // Handle unknown roles or any other custom logic
                        return RedirectToPage("/Error"); // Redirect to an error page or handle it as appropriate.

                }
            }

            // If user authentication fails, redirect back to the login page
            return RedirectToPage("/Login");
        }

    }
}