using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorApp.Models
{
    [Table("region")]
    public class Region
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } 
    }
}
