using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBproject.models;

namespace DBproject.Pages
{
    public class PDFModel : PageModel
    {
       DB db;

        public PDFModel()
        {
            db = new DB();
        }

        [BindProperty]
        public int Year { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Chapter { get; set; }

        [BindProperty]
        public string MultimediaLink { get; set; }
        [BindProperty]
        public long TId { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPostAddMultimedia()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.AddPdf(MultimediaLink, Year, Chapter, Title , 27805190300771);
                    return RedirectToPage("Teacher"); 
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while adding the PDF.");
                    Console.WriteLine(ex.Message);
                }
            }

            return Page();
        }
    }
}
