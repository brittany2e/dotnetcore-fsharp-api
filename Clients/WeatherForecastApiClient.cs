using System;
using System.Collections.Generic;

namespace Clients
{
    public class WeatherForecastApiClient
    {
        private readonly List<string> summaries = new List<string> { "freezing", "bracing", "chilly", "cool", "mild", "warm", "balmy", "hot", "sweltering", "scorching" };

        public WeatherResponse GetWeatherForecast()
        {
            // This isn't really an http client...
            // TODO: Call a public api somewhere for fun

            var random = new Random();
            var forecast = new List<WeatherDto>();

            for (int i = 0; i < 5; i++)
            {
                forecast.Add(new WeatherDto
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureF = random.Next(-20, 100),
                    Summary = summaries[random.Next(summaries.Count)]
                });
            }

            return new WeatherResponse
            {
                Forecast = forecast
            };
        }
    }
}
