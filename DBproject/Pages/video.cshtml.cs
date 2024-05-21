using DBproject.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBproject.Pages
{
    public class videoModel : PageModel
    {
        DB db;

        public videoModel()
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

        public void OnGet()
        {
        }

        public IActionResult OnPostAddMultimedia()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.AddVideo(MultimediaLink, Year, Chapter, Title, 27805190300771);
                    return RedirectToPage("/Teacher");
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
