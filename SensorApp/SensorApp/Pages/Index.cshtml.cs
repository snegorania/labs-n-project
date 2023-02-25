using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SensorApp.Models;

namespace SensorApp.Pages
{
    public class IndexModel : PageModel
    {
        /*private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/

        /*string reg;
        public string DisplayReg { get; set; }*/
        private DatabaseContext db;
        public IndexModel(DatabaseContext _db)
        {
            db = _db;
        }

        public List<User> Users { get; set; }
       

        public void OnGet()
        {
            //DisplayReg = reg;
            Users = db.Users.ToList();
            

        }

        public void OnPostPrint()
        {
            Mail.sendEmail();
        }
    }
}