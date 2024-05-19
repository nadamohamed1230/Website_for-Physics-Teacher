using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBproject.Pages
{
    public class TeacherModel : PageModel
    {
        [BindProperty]
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
        public string CorrectAnswer { get; set; }

        [BindProperty]
        public string Hardness { get; set; }
        [BindProperty]
        public string Topic { get; set; }
        [BindProperty]
        public int StudyLevel { get; set; }
        [BindProperty]
        public int NumQuestions { get; set; }

        [BindProperty]
        public string Year { get; set; }
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string MultimediaLink { get; set; }

        [BindProperty]
        public string TaEmail { get; set; }

        public List<Student> Students { get; set; }
        public List<Payment> Payments { get; set; }

        public void OnGet()
        {
            // Initialize lists or fetch data from a database
            Students = new List<Student>
        {
            new Student { Id = 1, Name = "ÌÊ”›", Phone = "0123456789" },
            new Student { Id = 2, Name = "„Õ„œ", Phone = "01123456789" }
        };

            Payments = new List<Payment>
        {
            new Payment { Id = 1, StudentName = "ÌÊ”›", NationalId = "621919561951", PaymentStatus = " „ «·œ›⁄" },
            new Payment { Id = 2, StudentName = "„Õ„œ", NationalId = "951919819819", PaymentStatus = "·„ Ì „ «·œ›⁄" }
        };
        }

        public IActionResult OnPostAddQuestion()
        {
            // Add question to the database or process it as needed
            // ...

            return RedirectToPage();
        }

        public IActionResult OnPostGenerateQuiz()
        {
            // Generate quiz based on provided data
            // ...

            return RedirectToPage();
        }

        public IActionResult OnPostAddMultimedia()
        {
            // Add multimedia link to the database or process it as needed
            // ...

            return RedirectToPage();
        }

        public IActionResult OnPostDeleteStudent(int id)
        {
            // Delete student from the database or process it as needed
            // ...

            return RedirectToPage();
        }

        public IActionResult OnPostUpdateStudent(int id)
        {
            // Update student details in the database or process it as needed
            // ...

            return RedirectToPage();
        }

        public IActionResult OnPostAddTa()
        {
            // Add teaching assistant using provided email
            // ...

            return RedirectToPage();
        }

        public IActionResult OnPostConfirmPayment(int id)
        {
            // Confirm payment and activate subscription
            // ...

            return RedirectToPage();
        }
    }

}


public class Student
{
    public int Id { get; set; }
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
