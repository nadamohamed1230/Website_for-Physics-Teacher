using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBproject.models;

namespace DBproject.Pages
{
    public class updateAModel : PageModel
    {
        [BindProperty]
        public TAs TA { get; set; }

        public void OnGet(long id)
        {
            DB db = new DB();
            TA = db.GetAssistantById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DB db = new DB();
            db.UpdateAssistant(TA);

            return RedirectToPage("TA");
        }
    }
}
