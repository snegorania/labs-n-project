using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FusionCharts.DataEngine;
using FusionCharts.Visualization;
using SensorApp.Models;
using System.Data;

namespace SensorApp.Pages.TablePages
{
    public class TableIndicationsModel : PageModel
    {
        private DatabaseContext db;
        public TableIndicationsModel(DatabaseContext _db)
        {
            db = _db;
        }

        public List<Indication> Indications { get; set; }
        public List<Sensor> Sensors { get; set; }
        public string ChartJson { get; internal set; }
        public void OnGet()
        {
            Indications = db.Indications.ToList();
            Sensors = db.Sensors.ToList();

            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Sensor", typeof(System.String));
            ChartData.Columns.Add("Temperature", typeof(System.Double));

            TimeSpan Interval = new TimeSpan(10, 0, 0);
            foreach(var indication in Indications)
            {
                if(indication.Time_Indication == Interval)
                {
                    foreach(var sensor in Sensors)
                    {
                        if (indication.Id_Sensor == sensor.Id)
                        {
                            ChartData.Rows.Add(sensor.Name, indication.Temperature);
                        }
                    }
                }
            }
            StaticSource source = new StaticSource(ChartData);
            DataModel model = new DataModel();
            model.DataSources.Add(source);
            Charts.ColumnChart column = new Charts.ColumnChart("first_chart");
            column.Width.Pixel(700);
            column.Height.Pixel(400);
            column.Data.Source = model;
            column.Caption.Text = "Temperature on Belarus";
            column.SubCaption.Text = "23.09.2023 10:00:00";
            column.Legend.Show = false;
            column.XAxis.Text = "Sensor";
            column.YAxis.Text = "Temperature";
            column.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            ChartJson = column.Render();
        }
    }
}
