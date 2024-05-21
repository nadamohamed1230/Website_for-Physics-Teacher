using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using DBproject.Models;

namespace DBproject.Pages
{
    public class TeacherModel : PageModel
    {
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
        [BindProperty]
        public string NID { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Password { get; set; }

<<<<<<< HEAD
        public List<Student> Students { get; set; }
        public List<Payment> Payments { get; set; }
        public List<TAs> TAs { get; set; }
        public User CurrentUser { get; set; }
        public void OnGet()
        {
            // Initialize lists or fetch data from a database
            CurrentUser = HttpContext.Session.GetObject<User>("CurrentUser");
            Students = GetStudentsFromDatabase();
            Payments = GetPaymentsFromDatabase();
            TAs = GetTAsFromDatabase();
=======

        public void OnGet()
        {

>>>>>>> 688e420e94ccdbe4733a190d02bf0171a14037bb
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

      

       
    }


   
}
