namespace TddWeatherApi.AppServices.Models.DTOs
{
    public class ResponseModelSysDto
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
