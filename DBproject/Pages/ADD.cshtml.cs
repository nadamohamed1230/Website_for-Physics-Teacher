
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBproject.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public string NID { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPostAddTA()
        {
            if (ModelState.IsValid)
            {
                // Add the TA to the database or process the form as needed
                // ...

                return RedirectToPage("Teacher");
            }

            return Page();
        }
    }
}
