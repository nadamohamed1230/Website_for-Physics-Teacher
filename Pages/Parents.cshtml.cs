using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using DBproject.Models;

namespace DBproject.Pages
{
    public class ParentsModel : PageModel
    {
        public User CurrentUser { get; set; }

        public void OnGet()
        {

        CurrentUser = HttpContext.Session.GetObject<User>("CurrentUser");
        }
    }
}
