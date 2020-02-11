using System;
using System.Collections.Generic;

namespace Clients
{
    public class WeatherResponse
    {
        public IEnumerable<WeatherDto> Forecast { get; set; }
    }
}
