namespace Dtos

open System
open System.Collections

type GetWeatherForecastResponse =
    {
        Forecast: IEnumerable
    }


type NewsSummary = 
    {
        Headline : string
        Body : string
    }
   
type GetNewsResponse = 
    {
        Date : DateTime
        Articles : List<NewsSummary>
    }
