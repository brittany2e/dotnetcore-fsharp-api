namespace FsharpApi.Modules

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Clients
open FsharpApi.Repositories.News
open FsharpApi.Modules.LocalNews.Mappers

[<ApiController>]
[<Route("[controller]")>]
type LocalNewsController (logger : ILogger<LocalNewsController>
    , repository : LocalNewsRepository
    ) =
    inherit ControllerBase()

    ///
    /// Get local news for today.
    ///
    [<HttpGet>]
    member __.GetLocalNewsForToday() : GetNewsResponse =
        let today = new DateTime.Today

        repository.GetLocalNews today
        |> NewsMapper.MapList
