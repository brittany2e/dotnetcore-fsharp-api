namespace FSharpApi.News

open System
open Npgsql.FSharp
open FSharpApi.News.Types

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

    let private _getNewsForTesting = 
        [|
            {
                id = Guid.NewGuid()
                headline = "Breathing oxygen linked to staying alive"
                body = "A groundbreaking discovery brought to you by the same scientific minds who discovered the link between walking and leaving the house."
                date = DateTime.Today
                author = "Kendal H. https://bestlifeonline.com/funniest-newspaper-headlines-of-all-time/"
                category = (int64)42

            }
        |] |> Array.toList

    let getInstance (connectionString:string) =
      { 
          new IDataAccess with
          member _.GetLocalNews calDate = _getNewsForTesting //_getLocalNews connectionString calDate
      }