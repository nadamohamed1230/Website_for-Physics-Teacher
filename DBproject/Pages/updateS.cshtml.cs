using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DBproject.Pages
{
    public class updateStModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }

        public void OnGet(int id)
        {
            // Fetch the student details from the database using the ID
            Student = GetStudentById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update student details in the database
            UpdateStudentInDatabase(Student);

            return RedirectToPage("Teacher");
        }

        private Student GetStudentById(int id)
        {
            // This should fetch the student details from the database.
            // For the sake of example, we are using hardcoded data.
            var students = new List<Student>
            {
                new Student { NId = 1, Name = "íæÓÝ", Phone = "0123456789" },
                new Student { NId = 2, Name = "ãÍãÏ", Phone = "01123456789" }
            };

            return students.FirstOrDefault(s => s.NId == id);
        }

        private void UpdateStudentInDatabase(Student student)
        {
            // This should update the student details in the database.
            // Implement database update logic here.
            // For the sake of example, we are using hardcoded data.
            var students = new List<Student>
            {
                new Student { NId = 1, Name = "íæÓÝ", Phone = "0123456789" },
                new Student { NId = 2, Name = "ãÍãÏ", Phone = "01123456789" }
            };

            var studentToUpdate = students.FirstOrDefault(s => s.NId == student.NId);
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = student.Name;
                studentToUpdate.Phone = student.Phone;
                // Save changes to the database or data store
            }
        }
    }

   
}
