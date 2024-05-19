using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DBproject.Pages
{
    public class S3Model : PageModel
    {
        public List<ModuleItem> Module1Items { get; set; }
        public List<ModuleItem> Module2Items { get; set; }

        public void OnGet()
        {
            Module1Items = new List<ModuleItem>
            {
                new ModuleItem { Index = 1, Title = "«· Ì«— «·ﬂÂ—»Ï Êﬁ«‰Ê‰ «Ê„", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "30:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" },
                new ModuleItem { Index = 2, Title = "«·ÃÂœ Ê«·„ﬁ«Ê„…", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "25:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" },
                new ModuleItem { Index = 3, Title = "ﬁ«‰Ê‰ ﬂÌ—‘Ê›", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "40:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" }
            };

            Module2Items = new List<ModuleItem>
            {
                new ModuleItem { Index = 1, Title = "«· √ÀÌ—«·„€‰«ÿÌ”Ï ·· Ì«—«·ﬂÂ—»Ï", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "20:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" },
                new ModuleItem { Index = 2, Title = "√ÃÂ“Â «·ﬁÌ«” «·ﬂÂ—»Ï", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "15:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" },
                new ModuleItem { Index = 3, Title = "«·„Ã«· «·„€‰«ÿÌ”Ì ·”·ﬂ", VideoUrl = "https://youtu.be/g6NWRPSoDm4?feature=shared", Duration = "22:30", PdfUrl = "https://drive.google.com/file/d/1IrRHCcEi_PUAS9F12W-J-QvoudFyaaTs/view?usp=sharing" }
            };
        }
    }


}
