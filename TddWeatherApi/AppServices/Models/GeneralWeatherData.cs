namespace TddWeatherApi.AppServices.Models
{
    public class GeneralWeatherData
    {
        public double Temperature { get; set; }
        public double PerceivedTemperature { get; set; }
        public double MinimalTemperature { get; set; }
        public double MaximalTemperature { get; set; }
        public int Pressure { get; set; }
        public double Humidity { get; set; }
    }
}