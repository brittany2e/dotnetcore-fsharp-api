namespace FSharpApi.News

open System
open System.Linq
open FSharpApi.News.Resources
open FSharpApi.News.Types

module Mapper =

    let MapNews news =
        {
            Headline = news.headline
            Body = news.body
        }

    let MapList newsList date = 
        let newsList = List.map MapNews newsList
        
        {
            Date = date
            Articles = newsList
        }
    