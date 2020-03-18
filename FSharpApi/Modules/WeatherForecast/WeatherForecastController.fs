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
    member __.GetWeatherForecast( startDate:string, endDate:string ) = 
        // Actual dates
        let couldParseStart, parsedStartDate = System.DateTimeOffset.TryParse(startDate)
        let couldParseEnd, parsedEndDate = System.DateTimeOffset.TryParse(endDate)
        match couldParseStart, couldParseEnd with
        | true,  true  -> ()
        | true,  false -> failwith (sprintf "Could not parse end date: %s" endDate)
        | false, true  -> failwith (sprintf "Could not parse start date: %s" startDate)
        | false, false -> failwith (sprintf "Could not parse dates: %s and %s" startDate endDate)

        // End date after start date
        // End date is less than 8 days from start date
        let timespan = parsedEndDate - parsedStartDate
        let oneDay = new TimeSpan (1, 0, 0, 0) 
        let eightDays = new TimeSpan (8, 0, 0, 0)
        match timespan with 
        | t when t < oneDay     -> failwith (sprintf "Make a bigger time span. %s and %s" startDate endDate)
        | t when t >= eightDays -> failwith (sprintf "Make a time span less than 8 days. %s and %s" startDate endDate)
        | _                     -> ()

        // Do the query (return result case)
        let forecast = repository.GetWeatherForecast parsedStartDate parsedEndDate
        
        // Data exists for the date period in that location


        Mapper.MapList forecast
        
        
