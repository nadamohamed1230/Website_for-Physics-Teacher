using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using DBproject.Models;
using System.Threading.Tasks;

namespace DBproject.Pages
{
    public class ProfileModel : PageModel
    {
          [BindProperty]
        public User CurrentUser { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public string NewEmail { get; set; }

        private readonly DB _db;

        public ProfileModel(DB db)
        {
            _db = db;
        }

        public void OnGet()
        {
            CurrentUser = HttpContext.Session.GetObject<User>("CurrentUser");

            // Proceed with the rest of the logic
            //return Page();
        }

        public async Task<IActionResult> OnPostChangePasswordAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = HttpContext.Session.GetObject<User>("CurrentUser");
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            user.Password = NewPassword;
            await _db.UpdateUserPasswordAsync(user.ID, NewPassword);

            // Update the session with the new password
            HttpContext.Session.SetObject("CurrentUser", user);

            return RedirectToPage("/Profile");
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = HttpContext.Session.GetObject<User>("CurrentUser");
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            user.Email = NewEmail;
            await _db.UpdateUserEmailAsync(user.ID, NewEmail);

            // Update the session with the new email
            HttpContext.Session.SetObject("CurrentUser", user);

            return RedirectToPage("/Profile");
        }
    }
}
