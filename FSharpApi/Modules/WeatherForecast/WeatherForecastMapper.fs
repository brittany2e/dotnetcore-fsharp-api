namespace FSharpApi.WeatherForecast

open System
open System.Linq
open FSharpApi.WeatherForecast.Resources
open FSharpApi.WeatherForecast.Types

module Mapper =

    let MapWeather (weather:WeatherPrediction) =
        let day = weather.Date.DayOfWeek
        String.Format("The weather forecast for {0} is {1} at {2} degrees F.", day, weather.Summary, weather.TemperatureF)
    
    let MapList weatherForecastList =
        let forecast = List.map MapWeather weatherForecastList
        {
            Forecast = forecast
        }

    