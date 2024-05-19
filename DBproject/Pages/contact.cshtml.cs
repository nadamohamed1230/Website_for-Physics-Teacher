using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBproject.Pages
{
    public class contactModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Subject { get; set; }
        [BindProperty]
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostSubmit()
        {
            // Handle the form submission logic here
            // For example, save the data to a database or send an email

            // Redirect or return a result
            return RedirectToPage("Contact");
        }
    }
}





