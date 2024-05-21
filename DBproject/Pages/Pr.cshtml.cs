using DBproject.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;


namespace DBproject.Pages
{
    public class PrModel : PageModel
    {
        public List<QuizStudent> Quizzes { get; set; }

        public void OnGet(long id)
        {
            DB db = new DB();
            Quizzes = db.GetStudentQuizzes(id);
        }
    }

  
}
