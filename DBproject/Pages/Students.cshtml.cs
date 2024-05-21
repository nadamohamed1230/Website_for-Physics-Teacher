using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBproject.models;
using System.Collections.Generic;
using DBproject.models;

namespace DBproject.Pages
{
    public class StudentsModel : PageModel
    {
        public List<Student> Students { get; set; }

        public void OnGet()
        {
            DB db = new DB();
            Students = db.GetStudents();
        }

        public IActionResult OnPostConfirmPayment(string id)
        {
            DB db = new DB();
            // Get current pay state and toggle it
            var student = db.GetStudents().Find(s => s.NId == id);
            if (student != null)
            {
                string newPayState = student.PayState == "Active" ? "Inactive" : "Active";
                db.UpdateStudentPaymentStatus(id, newPayState);
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDeleteStudent(string id)
        {
            DB db = new DB();
            db.DeleteStudent(id);
            return RedirectToPage();
        }
    }
}
