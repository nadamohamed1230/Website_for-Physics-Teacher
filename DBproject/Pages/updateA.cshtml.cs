using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DBproject.Pages
{
    public class updateAModel : PageModel
    {
        [BindProperty]
        public TAs TA { get; set; }

        public void OnGet(int id)
        {
            // Fetch the TA details from the database using the ID
            TA = GetTAById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update TA details in the database
            UpdateTAInDatabase(TA);

            return RedirectToPage("Teacher");
        }

        private TAs GetTAById(int id)
        {
            var ass = new List<TAs>
            {
                new TAs { NID = 1, Name = "íæÓÝ", Phone = "0123456789" },
                new TAs { NID = 2, Name = "ãÍãÏ", Phone = "01123456789" }
            };

            return ass.FirstOrDefault(a => a.NID == id);
        }

        private void UpdateTAInDatabase(TAs t)
        {
            // This should update the TA details in the database.
            // Implement database update logic here.
            // For the sake of example, we are using hardcoded data.
            var ass = new List<TAs>
            {
                new TAs { NID = 1, Name = "íæÓÝ", Phone = "0123456789" },
                new TAs { NID = 2, Name = "ãÍãÏ", Phone = "01123456789" }
            };

            var TAToUpdate = ass.FirstOrDefault(s => s.NID == t.NID);
            if (TAToUpdate != null)
            {
                TAToUpdate.Name = t.Name;
                TAToUpdate.Phone = t.Phone;
                // Save changes to the database or data store
            }
        }
    }

   
}
