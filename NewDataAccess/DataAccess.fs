namespace FSharpApi.News

open System
open Npgsql.FSharp
open Npgsql.FSharp.OptionWorkflow
open FSharpApi.News.DTO.Types

module DataAccess = 

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