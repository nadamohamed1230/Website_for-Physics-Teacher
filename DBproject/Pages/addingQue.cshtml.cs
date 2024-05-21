using DBproject.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DBproject.Pages
{
    public class addingQueModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        [Required(ErrorMessage = "enter questions")]
        public string Question { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "enter answer")]
        public string Answer1 { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "enter answer")]
        public string Answer2 { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "enter answer")]
        public string Answer3 { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "enter answer")]
        public string Answer4 { get; set; }
        [BindProperty]
        public string CorrectAnswer { get; set; }
        [BindProperty]
        public int ac_year { get; set; }
        [BindProperty]
        public int Hardness { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "enter chapter")]
        public string chapter { get; set; }

        public addingQueModel(DB db)
        {
            this.db = db;
        }


        public void OnGet()
        {
        }


        public IActionResult OnPostAddQuestion()
        {
            if (ModelState.IsValid)
            {


                string ch = chapter;
                string q = Question;

                if (CorrectAnswer == "answer1")
                    CorrectAnswer = Answer1;
                else if (CorrectAnswer == "answer2")
                    CorrectAnswer = Answer2;
                else if (CorrectAnswer == "answer3")
                    CorrectAnswer = Answer3;
                else if (CorrectAnswer == "answer4")
                    CorrectAnswer = Answer4;



                if (ac_year == 1)
                    ac_year = 1;
                else if (ac_year == 2)
                    ac_year = 2;
                else if (ac_year == 3)
                    ac_year = 3;


                if (Hardness == 1)
                    Hardness = 1;
                if (Hardness == 2)
                    Hardness = 2;
                else if (Hardness == 3)
                    Hardness = 3;
                db. AddQuestions(ch, Hardness, ac_year, 27805190300771, q, Answer1, Answer2, Answer3, Answer4, CorrectAnswer);


                return RedirectToPage();

            }
            return Page();
        }
    }
}
