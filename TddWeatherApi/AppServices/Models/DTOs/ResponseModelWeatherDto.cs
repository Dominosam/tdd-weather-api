namespace TddWeatherApi.AppServices.Models.DTOs
{
    public class ResponseModelWeatherDto
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
