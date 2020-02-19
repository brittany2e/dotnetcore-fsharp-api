namespace FSharpApi.News

open System
open Npgsql.FSharp
open Npgsql.FSharp.OptionWorkflow
open FSharpApi.News.DTO.Types

module DataAccess = 

    type IDataAccess =
      abstract GetLocalNews : calDate:DateTime -> News list


    let private _getLocalNews (connectionString:string) (date:DateTime) =
      connectionString
      |> Sql.connect
      |> Sql.query "select * from local_news where recorded_date = @date"
      |> Sql.parameters ["date", Sql.Value date]
      |> Sql.executeTable
      |> Sql.parseEachRow<News>

    let getInstance (connectionString:string) =
      { new IDataAccess with
          member _.GetLocalNews calDate = _getLocalNews connectionString calDate
      }

    //type NewsRepository(connectionString:string) =
        
    //    let getLocalNews (date:DateTime) = 
    //        connectionString
    //        |> Sql.connect
    //        |> Sql.query "select * from local_news where recorded_date = @date"
    //        |> Sql.parameters ["date", Sql.Value date]
    //        |> Sql.executeTable
    //        |> Sql.parseEachRow<News>

    //    member _.GetLocalNews date =
    //        getLocalNews date