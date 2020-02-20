namespace FSharpApi.WeatherForecast.DTO

open System


module Types =

  type WeatherPrediction = {
    DateTimeOffset : DateTimeOffset
    Description : string
    Temperature : float
  }


