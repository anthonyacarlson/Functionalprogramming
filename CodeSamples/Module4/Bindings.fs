module Bindings

open Xunit
open FsUnit.Xunit
open System.Threading.Tasks
open System.Net.Http
open System.Collections.Generic
open System.Data
open System.IO
open FSharp.Data


[<Fact>]
let ``let bindings`` () = 
    let age = 25

    // function with signature of int -> int
    let ageInMonths ageInYears = ageInYears * 12
    //        or with types...
    //           parameter type --\/      \/-- return type
    //let ageInMonths (ageInYears : int) : int = ageInYears * 12

    0

//
// do examples
// 
[<Fact>]
let ``do binding`` () = 
    let age = 25

    do printfn "My age is %i" age

    // this is also valid
    printfn "My age is %i" age


//
// use examples
// 
[<Fact>]
let ``use binding`` () = 
    let readByteFromStream =
        use stream = new MemoryStream([| 1uy |]) // initialize stream with a byte of 1
        let byte = stream.ReadByte()
        byte

    0

//
// computation expression examples
//

//
// async computation expression
//

// generic request

// request returns the type 'Async<string>'
let request url = 
    async {
        let! response = Http.AsyncRequestString url
        return response
    }

[<Fact>]
let ``get time async function`` () = 


    // html is of type 'string'
    let html = 
        request "http://google.com" 
        |> Async.RunSynchronously

    // WARNING : Observe the same call context  
    //    threading rules as you would with C#

    printfn "%A" html

    // specific request using generic request
    let getTime timeZone =
        async {
            // while in an F# async block, the let! has a similar affect as C#'s await

            let! jsonResponse = request <| sprintf "http://worldclockapi.com/api/json/%s/now" timeZone

            return jsonResponse
        }
        // async is actually an instance of AsyncBuilder, 
        //   when you use let! it calls the async.Bind member

   
    // getTime's signature is string -> Async<string>.  
    // It returns a generic Async of string.  
    // Not unlike Task<string>.
    // Because this is a console app we can use Async.RunSynchronously to get the value out

    let time = getTime "est" |> Async.RunSynchronously

    printfn "%s" time

[<Fact>]
let ``async http test`` () = async {

    let! html = 
        request "http://google.com" 

    html.Length |> should be (greaterThan 1)
}


[<Fact>]
let ``linq query function`` () = 
    //
    // query computation expression
    //
    let linqComputationExpression =
        let names = [| "John"; "Jane" |]
        let nameQuery =
            query {
                for name in names do
                select name
            }
            // query is actually an instance of Linq.QueryBuilder, when you use select then it calls the query.Select member

        // nameQuery is a sequence of string
        nameQuery |> 
            Seq.iter (printfn "%s")


    0






//
// Bonus bindings
//

// Units of measure

[<Measure>]
type gallons

[<Measure>]
type miles

[<Fact>]
let ``measures`` () = 

    let gallonsUsed = 4.8<gallons>

    let milesDriven = 180.0<miles>

    let milesPerGallon : float<miles/gallons> = milesDriven / gallonsUsed 

    // This creates a compilation error, the measures are reversed
    //let milesPerGallon : float<miles/gallons> = gallonsUsed / milesDriven

    0