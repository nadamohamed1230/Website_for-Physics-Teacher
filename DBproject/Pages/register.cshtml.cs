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
                _db.RegisterUser(NewUser);
                return RedirectToPage("/Login");
            }
            return Page();
        }
    }
}
