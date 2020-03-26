namespace FSharpApi.WeatherForecast

open System
open FSharp.Data.Sql
open FSharpApi.WeatherForecast.Types

module DataAccess =

    type IDataAccess = 
        abstract GetWeatherForecast : startTime:DateTimeOffset -> endTime:DateTimeOffset -> WeatherPrediction list
  
    type sql = SqlDataProvider<
        Common.DatabaseProviderTypes.POSTGRESQL,
        connectionString>

    let private ctx = sql.GetDataContext()

    let private _getWeatherForecast (connectionString:string) (startDate:DateTimeOffset) (endDate:DateTimeOffset) : WeatherPrediction list =
        connectionString
        // and then what?
    

    // Fake stuff
    //let private summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]
  
    //let private _getFakeWeatherForecast = 
    //let rng = System.Random()
    //    [|
    //    for index in 0..4 ->
    //        { 
    //            Date = DateTimeOffset.Now.AddDays(float index)
    //            TemperatureF = rng.Next(-20,55)
    //            Summary = summaries.[rng.Next(summaries.Length)] 
    //        }
    //    |] |> Array.toList
    // end fake stuff

    let getInstance (connectionString:string) =
    { 
        new IDataAccess with
        member _.GetWeatherForecast startDate endDate = _getWeatherForecast connectionString startDate endDate
    }