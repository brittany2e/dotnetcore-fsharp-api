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
        member this.GetWeatherForecast startDate endDate = []
    }

    let mockLogger = Mock<ILogger<WeatherForecastController>>().Create()
    
    [<Fact(DisplayName = "First")>]
    let ``Weather test`` () =
        Assert.True(true)

    [<Property(DisplayName = "Second")>] // Notice Property keyword
    let ``Weather controller property test`` (startDate:DateTimeOffset, timeSpan:TimeSpan) = // automatically inserts values
        let endDate = startDate.Add(timeSpan)
        let controller = new WeatherForecastController(mockLogger, mockDataAcess)

        let result = controller.GetWeatherForecast(startDate, endDate)
        
        Assert.True(result.Forecast.IsEmpty)


