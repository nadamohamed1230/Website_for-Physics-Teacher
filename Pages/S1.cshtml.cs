using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using DBproject.Models;
using System.Collections.Generic;

namespace DBproject.Pages
{
    public class S1Model : PageModel
    {
        public List<ModuleItem> Module1Items { get; set; }
        public List<ModuleItem> Module2Items { get; set; }
        public User CurrentUser { get;  set; }

        public void OnGet()
        {
            CurrentUser = HttpContext.Session.GetObject<User>("CurrentUser");

            Module1Items = new List<ModuleItem>
            {
                new ModuleItem { Index = 1, Title = "المحاضرة الأولى عن المصفوفات والمتجهات", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "30:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" },
                new ModuleItem { Index = 2, Title = "المحاضرة الثانية عن الدوال والمعادلات", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "25:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" },
                new ModuleItem { Index = 3, Title = "المحاضرة الثالثة عن الحساب التفاضلي", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "40:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" }
            };

            Module2Items = new List<ModuleItem>
            {
                new ModuleItem { Index = 1, Title = "المحاضرة الأولى عن منهج العلوم العسكرية", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "20:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" },
                new ModuleItem { Index = 2, Title = "المحاضرة الثانية عن الحروب والقتال", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "15:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" },
                new ModuleItem { Index = 3, Title = "المحاضرة الثالثة عن أساليب البحث العلمي", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "22:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" }
            };
        }
    }
    
    public class ModuleItem
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public string Duration { get; set; }
        public string PdfUrl { get; set; }
    }
}
