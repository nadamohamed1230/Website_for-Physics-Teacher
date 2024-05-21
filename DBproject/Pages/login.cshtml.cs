using DBproject.Models;
using DBproject.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace DBproject.Pages
{

    public class LoginModel : PageModel
    {
        private readonly DB _db;

        [BindProperty]
        public long ID { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Role { get; set; }
        public string Msg;
        public LoginModel(DB db)
        {
            _db = db;
        }

        //public async Task<IActionResult> OnPostLoginAsync()
        //{
        //    var user = await _db.GetUserByUsernameAndPasswordAsync(ID, Password);
        //    if (user != null)
        //    {
        //        HttpContext.Session.SetObject("CurrentUser", user);
        //        return RedirectToPage("/Profile");
        //    }

        //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    return Page();
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _db.ValidateUserAsync(ID, Password, Role);
            if (user == null)
            {
                Msg = "Invalid login attempt";
                return Page();
            }
            HttpContext.Session.SetObject("CurrentUser", user);
            return RedirectToCorrectPage(user);
        }

        private IActionResult RedirectToCorrectPage(User user)
        {
            // Redirect users based on their role and academic year
            switch (user.Role)
            {
                case "teacher":
                    return RedirectToPage("/Teacher");
                case "assistant":
                    return RedirectToPage("/Assistant");
                case "student":
                    return RedirectToStudentPage(user.AcademicYear);
                case "parent":
                    return RedirectToPage("/Parent");
                default:
                    // Handle unknown roles or any other custom logic
                    return RedirectToPage("/Error");
            }
        }

        private IActionResult RedirectToStudentPage(int academicYear)
        {
            switch (academicYear)
            {
                case 1:
                    return RedirectToPage("/S1");
                case 2:
                    return RedirectToPage("/S2");
                case 3:
                    return RedirectToPage("/S3");
                default:
                    // Handle unknown academic years
                    return RedirectToPage("/Error");
            }
        }
    }
}