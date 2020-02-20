namespace FSharpApi.WeatherForecast

open System

module DataAccess =

  type IDataAccess = 
   abstract GetWeather : startTime:DateTimeOffset -> endTime:DateTimeOffset -> string
