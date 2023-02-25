using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorApp.Models
{
    [Table("sensor")]
    public class Sensor
    {
        [Key]
        public int Id { get; set; }
        public int Id_Region { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
