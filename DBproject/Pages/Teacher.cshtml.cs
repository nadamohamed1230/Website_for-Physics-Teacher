using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DBproject.Pages
{
    public class TeacherModel : PageModel
    {
/*        [BindProperty]
        public string Question { get; set; }
        [BindProperty]
        public string Answer1 { get; set; }
        [BindProperty]
        public string Answer2 { get; set; }
        [BindProperty]
        public string Answer3 { get; set; }
        [BindProperty]
        public string Answer4 { get; set; }
        [BindProperty]
        public string CorrectAnswer { get; set; }*/

/*        [BindProperty]
        public string Hardness { get; set; }
        [BindProperty]
        public string Topic { get; set; }
        [BindProperty]
        public int StudyLevel { get; set; }
        [BindProperty]
        public int NumQuestions { get; set; }*/

        [BindProperty]
        public string Year { get; set; }
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string MultimediaLink { get; set; }

        [BindProperty]
        public string TaEmail { get; set; }

        [BindProperty]
        public string NID { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public List<Student> Students { get; set; }
        public List<Payment> Payments { get; set; }
        public List<TAs> TAs { get; set; }

        public void OnGet()
        {
            // Initialize lists or fetch data from a database
            Students = GetStudentsFromDatabase();
            Payments = GetPaymentsFromDatabase();
            TAs = GetTAsFromDatabase();
        }

        private List<Student> GetStudentsFromDatabase()
        {
            // This should fetch the student details from the database.
            // For the sake of example, we are using hardcoded data.
            return new List<Student>
            {
                new Student { NId = 1, Name = "ÌÊ”›", Phone = "0123456789" },
                new Student { NId = 2, Name = "„Õ„œ", Phone = "01123456789" }
            };
        }

        private List<Payment> GetPaymentsFromDatabase()
        {
            // This should fetch the payment details from the database.
            // For the sake of example, we are using hardcoded data.
            return new List<Payment>
            {
                new Payment { Id = 1, StudentName = "ÌÊ”›", NationalId = "621919561951", PaymentStatus = " „ «·œ›⁄" },
                new Payment { Id = 2, StudentName = "„Õ„œ", NationalId = "951919819819", PaymentStatus = "·„ Ì „ «·œ›⁄" }
            };
        }

        private List<TAs> GetTAsFromDatabase()
        {
            // This should fetch the TA details from the database.
            // For the sake of example, we are using hardcoded data.
            return new List<TAs>
            {
                new TAs { NID = 1, Name = "ÌÊ”›", Phone = "0123456789" },
                new TAs { NID = 2, Name = "„Õ„œ", Phone = "01123456789" }
            };
        }

        public IActionResult OnPostAddQuestion()
        {
            // Add question to the database or process it as needed
            // ...

            return RedirectToPage("/addingQue");
        }

        public IActionResult OnPostGenerateQuiz()
        {
            // Generate quiz based on provided data
            // ...

            return RedirectToPage("/Randomquizform");
        }

        public IActionResult OnPostAddMultimedia()
        {
            // Add multimedia link to the database or process it as needed
            // ...

            return RedirectToPage();
        }

        public IActionResult OnPostAddTA()
        {
            if (NID.Length == 14)
            {
                // Add TA to the database or process it as needed
                // ...

                return RedirectToPage("Teacher");
            }
            ModelState.AddModelError("NID", "NID must be 14 characters long.");
            return Page();
        }

        public IActionResult OnPostDeleteStudent(int id)
        {
            // Delete student from the database or process it as needed
            // ...

            return RedirectToPage();
        }

        public IActionResult OnPostConfirmPayment(int id)
        {
            // Confirm payment for the student or process it as needed
            // ...

            return RedirectToPage();
        }
    }

    public class Student
    {
        public int NId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class Payment
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string NationalId { get; set; }
        public string PaymentStatus { get; set; }
    }

    public class TAs
    {
        public int NID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
