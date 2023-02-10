namespace SensorApp.Models
{
    public class Indication
    {
        public int Id { get; set; }
        public int IdSensor { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double Temperature { get; set; }
    }
}
