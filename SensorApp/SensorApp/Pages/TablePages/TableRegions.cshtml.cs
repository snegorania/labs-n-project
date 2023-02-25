using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SensorApp.Models;

namespace SensorApp.Pages.TablePages
{
    public class TableRegionsModel : PageModel
    {
		private DatabaseContext db;
		public TableRegionsModel(DatabaseContext _db)
		{
			db = _db;
		}

		public List<Region> Regions { get; set; }
		public void OnGet()
        {
			Regions = db.Regions.ToList();
		}

    }
}
