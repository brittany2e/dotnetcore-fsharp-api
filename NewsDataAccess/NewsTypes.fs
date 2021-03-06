﻿namespace FSharpApi.News

open System

module Types =

  type News = 
    {   
        id : Guid
        headline : string
        body : string
        date : DateTime
        author : string
        category : int64
    }
