using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SensorApp.Models;

namespace SensorApp.Pages.TablePages
{
    public class TableSensorsModel : PageModel
    {
		private DatabaseContext db;
		public TableSensorsModel(DatabaseContext _db)
		{
			db = _db;
		}

		public List<Sensor> Sensors { get; set; }
        public List<Region> Regions { get; set; }

        public void OnGet()
        {
			Sensors = db.Sensors.ToList();
			Regions = db.Regions.ToList();
		}
    }
}
