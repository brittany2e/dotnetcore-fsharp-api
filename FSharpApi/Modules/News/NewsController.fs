namespace FSharpApi.News

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]")>]
type LocalNewsController (logger : ILogger<LocalNewsController>
    , repository : DataAccess.IDataAccess
    ) =
    inherit ControllerBase()

    ///
    /// Get local news for today.
    ///
    [<HttpGet>]
    member __.GetLocalNewsForToday() =
        let localNews = repository.GetLocalNews DateTime.Today
        Mapper.MapList localNews DateTime.Today