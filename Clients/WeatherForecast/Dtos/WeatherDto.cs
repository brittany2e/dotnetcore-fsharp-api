using System;

namespace Clients
{
    public class WeatherDto
    {
        public DateTime Date { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}
