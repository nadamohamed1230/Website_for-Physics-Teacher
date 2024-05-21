using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using DBproject.models; // Make sure to include the namespace of your DB class

namespace DBproject.Pages
{
    public class TAModel : PageModel
    {

        public List<TAs> TAs { get; set; }

      

        public void OnGet()
        {
            DB db = new DB();
            TAs = db.GetAssistants(); // Call the method from your DB class to fetch TAs
        }

        public IActionResult OnPostDeleteTAs(string id)
        {
            //_db.DeleteTA(id); // Call the method from your DB class to delete TA
            return RedirectToPage();
        }
    }
}
