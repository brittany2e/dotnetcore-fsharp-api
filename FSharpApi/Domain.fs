namespace FsharpApi.Domain

open System

type News = 
    {   
        id : Guid
        headline : string
        body : string
        date : DateTime
        author : string
        category : int64
    }