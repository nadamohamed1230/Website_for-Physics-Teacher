using DBproject.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json;

namespace DBproject.Pages
{
    public class progressModel : PageModel
    {
        public DataTable grades { get; set; }
        private readonly DB db;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }

      

        public progressModel(DB db)
        {
            this.db = db;
        }

        public void OnGet()
        {

            //long id = this.id;
            id = HttpContext.Session.GetString("Nid")!;
            long ID = long.Parse(HttpContext.Session.GetString("Nid")!);

            // Dictionary<string, int> gradesreport = db.graphquizgrades(id);

            //setUpBarChart(gradesreport);

            grades = db.GetQuizGrades(ID);
        }
    }
}