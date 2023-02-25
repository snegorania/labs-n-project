using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorApp.Models
{
    [Table("indication")]
    public class Indication
    {
        [Key]
        public int Id { get; set; }
        public int Id_Sensor { get; set; }
        public DateTime Date_Indication { get; set; }
        public TimeSpan Time_Indication { get; set; }
        public double Temperature { get; set; }
    }
}
