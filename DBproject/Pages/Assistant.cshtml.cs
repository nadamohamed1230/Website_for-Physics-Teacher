using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBproject.Pages
{
    public class AssistantModel : PageModel
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

        public List<Student> Students { get; set; } = new List<Student>
    {
        new Student { NId = 1, Name = "ÌÊ”›", Phone = "0123456789" },
        new Student { NId = 2, Name = "„Õ„œ", Phone = "01123456789" }
    };

        public List<Payment> Payments { get; set; } = new List<Payment>
    {
        new Payment { Id = 1, StudentName = "ÌÊ”›", NationalId = "621919561951", PaymentStatus = " „ «·œ›⁄" },
        new Payment { Id = 2, StudentName = "„Õ„œ", NationalId = "951919819819", PaymentStatus = "·„ Ì „ «·œ›⁄" }
    };

        public void OnGet()
        {
        }

        public IActionResult OnPostAddQuestion()
        {
            // Add question logic
            return RedirectToPage("/addingQue");
        }

        public IActionResult OnPostGenerateQuiz()
        {
            // Generate quiz logic
            return RedirectToPage("/Randomquizform");
        }

        public IActionResult OnPostAddMultimedia()
        {
            // Add multimedia logic
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteStudent(int id)
        {
            // Delete student logic
            return RedirectToPage();
        }

        public IActionResult OnPostUpdateStudent(int id)
        {
            // Update student logic
            return RedirectToPage();
        }

        public IActionResult OnPostConfirmPayment(int id)
        {
            // Confirm payment logic
            return RedirectToPage();
        }
    }

}

