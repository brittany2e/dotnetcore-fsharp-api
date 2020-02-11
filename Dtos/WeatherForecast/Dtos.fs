namespace Dtos

open System.Collections

type GetWeatherForecastResponse =
    {
        Forecast: IEnumerable
    }
    