namespace FSharpApi.Tests

open System
open Xunit
open Microsoft.Extensions.Logging
open Foq
open FsCheck
open FsCheck.Xunit
open FSharpApi.WeatherForecast.DataAccess
open FSharpApi.WeatherForecast

module WeatherForecastControllerTests = 
    let mockDataAcess = { new IDataAccess with 
        member this.GetWeatherForecast startDate endDate = Result.Ok []
    }

    let mockLogger = Mock<ILogger<WeatherForecastController>>().Create()
    
    [<Fact(DisplayName = "This is the display name for the test.")>]
    let ``Weather test`` () =
        Assert.True(true)

    [<Property(DisplayName = "This is a property test")>] // Notice Property keyword
    let ``Weather controller property test`` (startDate:DateTimeOffset, timeSpan:TimeSpan) = // automatically inserts values
        let endDate = startDate.Add(timeSpan)
        let controller = new WeatherForecastController(mockLogger, mockDataAcess)

        let result = controller.GetWeatherForecast(startDate.ToString(), endDate.ToString())
        
        Assert.True(result.Forecast.IsEmpty)
