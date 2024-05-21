using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBproject.Models;
namespace DBproject.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly DB _db;

        public RegisterModel()
        {
            _db = new DB();
        }

        [BindProperty]
        public User NewUser { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                NewUser.PayState = "inactive";
                NewUser.TnID = "27805190300771";
                _db.RegisterUserAsync(NewUser);
                string redirectToPage;
                switch (NewUser.AcademicYear)
                {
                    case 1:
                        redirectToPage = "/S1";
                        break;
                    case 2:
                        redirectToPage = "/S2";
                        break;
                    case 3:
                        redirectToPage = "/S3";
                        break;
                    default:
                        redirectToPage = "/register";
                        break;
                }

                return RedirectToPage(redirectToPage );
            }
            return Page();
        }

    }
}
