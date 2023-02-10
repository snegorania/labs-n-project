using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SensorApp.Pages
{
    public class IndexModel : PageModel
    {
        /*private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/

        string reg;
        public string DisplayReg { get; set; }
        public IndexModel()
        {
            this.reg = quaryTry.ConnectionTry();
        }

        public void OnGet()
        {
            DisplayReg = reg;
        }

        public void OnPostPrint()
        {
            Mail.sendEmail();
        }
    }
}