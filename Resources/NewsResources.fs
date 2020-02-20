namespace FSharpApi.News

open System

module Resources = 

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