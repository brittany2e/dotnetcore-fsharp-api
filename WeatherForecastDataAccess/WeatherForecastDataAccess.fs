﻿namespace FSharpApi.WeatherForecast

open System
open Npgsql.FSharp
open FSharpApi.WeatherForecast.Types

module DataAccess =

  type IDataAccess = 
    abstract GetWeatherForecast : startTime:DateTimeOffset -> endTime:DateTimeOffset -> Result<WeatherPrediction list, string>

  let private _getWeatherForecast (connectionString:string) (startDate:DateTimeOffset) (endDate:DateTimeOffset) =
    try
        connectionString
        |> Sql.connect
        |> Sql.query "select * from weather_predictions where recorded_date > @start and recorded_date < @end"
        |> Sql.parameters ["start", Sql.Value startDate]
        |> Sql.parameters ["end", Sql.Value endDate]
        |> Sql.executeTable
        |> Sql.parseEachRow<WeatherPrediction>
        |> Result.Ok
    with
    | x -> Result.Error (x.Message)

  let private summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]
  
  let private _getFakeWeatherForecast : Result<WeatherPrediction list, string> = 
    let rng = System.Random()
    [|
    for index in 0..4 ->
        { 
            Date = DateTimeOffset.Now.AddDays(float index)
            TemperatureF = rng.Next(-20,55)
            Summary = summaries.[rng.Next(summaries.Length)] 
        }
    |] 
    |> Array.toList 
    |> Result.Ok
    
  let getInstance (connectionString:string) =
    { 
       new IDataAccess with
       member _.GetWeatherForecast startDate endDate = _getFakeWeatherForecast // _getWeatherForecast connectionString startDate endDate
    }