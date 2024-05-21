using DBproject.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBproject.Pages
{
    public class RandomquizformModel : PageModel
    {
        private readonly DB db;
        [BindProperty]
        public int Hardness { get; set; }
        [BindProperty]
        public string Topic { get; set; }
        [BindProperty]
        public int StudyLevel { get; set; }
        [BindProperty]
        public int NumQuestions { get; set; }

        public RandomquizformModel(DB db)
        {
            this.db = db;
        }

        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
           int id = db.idquiz()+1;
            int ac_yr = StudyLevel;
            int num_questions = NumQuestions;
            string topic = Topic;
            if (Hardness == 1)
                Hardness = 1;
            if (Hardness == 2)
                Hardness = 2;
            else if (Hardness == 3)
                Hardness = 3;

            db.addquiz(id, 27805190300771, topic, num_questions, ac_yr, Hardness);
            db.quizQuestion(num_questions,id,ac_yr, Hardness);

            return RedirectToPage();
        }

    }
}
