module AsyncLab

open Xunit
open FsUnit.Xunit
open FSharp.Data


let helperAsyncString str = async { return str }


// Exercise 1
// Create an async function that will return the string contents when given a url.
//      This approach would be applicable if you were creating a REST API method in a controller.
// NOTE: It might be helpful to check out the F# HTTP libraries help page. ;) https://fsharp.github.io/FSharp.Data/library/Http.html
let downloadAsync url : Async<string> =
    helperAsyncString "" // Remove this line as you start Exercise 1



// Exercise 2
// Create function that internally executes as async but then passes through Async.RunSynchronously before returning
//      This approach would be applicable if you were creating a Console app that has async calls.
let download url : string =
    ""  // Remove this line as you start Exercise 2



[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 1. single page download`` () = async {
// Notice that the entire test is surrounded by an async computation.  This isn't much different than a test in C# coded with the async/await pattern.

        let! html = downloadAsync "http://google.com" 
        html.Length |> should be (greaterThan 1)
    }


[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 2. single page download run synchronously`` () = 

    let html = download "http://google.com" 
    html.Length |> should be (greaterThan 1)
   
