using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBproject.models;

namespace DBproject.Pages
{
    public class updateStModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }

        private readonly DB _db;

        public updateStModel()
        {
            _db = new DB();
        }

        public void OnGet(string id)
        {
            // Fetch the student details from the database using the ID
            Student = _db.GetStudentById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update student details in the database
            _db.UpdateStudentInDatabase(Student);

            return RedirectToPage("Students");
        }
    }
}
