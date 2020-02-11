namespace FsharpApi.Modules.WeatherForecast.Mappers

open System
open System.Linq
open Clients
open Dtos

module WeatherForecastMapper =

    let MapWeather (weather:WeatherDto) =
        let day = weather.Date.DayOfWeek
        String.Format("The weather forecast for {0} is {1} at {2} degrees F.", day, weather.Summary, weather.TemperatureF)
    
    let Map (weatherForecast:WeatherResponse) =
        let forecast = weatherForecast.Forecast.Select(MapWeather)
        {
            Forecast = forecast
        }

    