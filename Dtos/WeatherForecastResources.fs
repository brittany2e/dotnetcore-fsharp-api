namespace FSharpApi.WeatherForecast.Resources

open System
open System.Collections

type GetWeatherForecastResponse =
    {
        Forecast: List<string>
    }
