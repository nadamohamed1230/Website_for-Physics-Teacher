using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBproject.models; 
using System.ComponentModel.DataAnnotations;

namespace DBproject.Pages
{
    public class ADDModel : PageModel
    {
        [BindProperty]
        public string NID { get; set; }

        [BindProperty]
        public string Fname { get; set; }

        [BindProperty]
        public string Lname { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                DB db = new DB();
                db.AddAssistant(NID, Fname, Lname, Phone, Password);

                return RedirectToPage("Teacher");
            }

            return Page();
        }
    }
}
