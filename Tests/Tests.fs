namespace FSharpApi.Tests

open System
open Xunit
open FsCheck
open FsCheck.Xunit

module ControllerTests = 

    [<Fact(DisplayName = "First")>]
    let ``My test`` () =
        Assert.True(true)

    [<Property(DisplayName = "Second")>] // Notice Property keyword
    let ``My new test`` (x:PositiveInt, y:PositiveInt) = // automatically inserts values
        Assert.True(x < y)

    
