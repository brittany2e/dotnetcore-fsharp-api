namespace FSharpApi.WeatherForecast

open System

module Types =

  type WeatherPrediction = {
    Date : DateTimeOffset
    Summary : string
    TemperatureF : int
  }


