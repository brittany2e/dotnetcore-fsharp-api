namespace FsharpApi.Repositories

open System
open Npgsql.FSharp
open Npgsql.FSharp.OptionWorkflow
open Microsoft.Extensions.Options
open FsharpApi.Domain.News

module News = 
    type NewsRepository(connectionString:string) =
        
        let getLocalNews (date:DateTime) = 
            connectionString
            |> Sql.connect
            |> Sql.query "select * from local_news where recorded_date = @date"
            |> Sql.parameters ["date", Sql.Value date]
            |> Sql.executeTable
            |> Sql.parseEachRow<News>

        member _.GetLocalNews date =
            getLocalNews date