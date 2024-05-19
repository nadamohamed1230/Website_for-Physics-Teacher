using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBproject.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string ID { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Role { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Implement your form submission logic here
            // Example: Validate the user, redirect based on role, etc.

            switch (Role)
            {
                case "student1":
                    return RedirectToPage("/S1");
                case "student2":
                    return RedirectToPage("/S2");
                case "student3":
                    return RedirectToPage("/S3");
                case "assistant":
                    return RedirectToPage("/Assistant");
                case "parents":
                    return RedirectToPage("/Parents");
                case "teacher":
                    return RedirectToPage("/Teacher");
                default:
                    // Handle invalid role
                    return Page();
            }
        }
    }
}
