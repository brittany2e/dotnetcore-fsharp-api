namespace FSharpApi.WeatherForecast

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open FSharpApi.WeatherForecast.Resources

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>
    , repository : DataAccess.IDataAccess
    ) =
    inherit ControllerBase()

    [<HttpGet>]
    member __.GetWeatherForecast( startDate, endDate )= 
        let forecast = repository.GetWeatherForecast startDate endDate
        Mapper.MapList forecast
        
        
