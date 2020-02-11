namespace FsharpApi.Modules

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Clients
open FsharpApi.Modules.WeatherForecast.Mappers

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>
    ) =
    inherit ControllerBase()

    [<HttpGet>]
    member __.Get() =
        // TODO Figure out the DI so this client can go in the constructor, 
        // but maybe that's not important since I am going to change this 
        // endpoint to use the repository stuff anyway.
        let client = new WeatherForecastApiClient()

        let forecast = client.GetWeatherForecast()
        WeatherForecastMapper.Map(forecast)
        
