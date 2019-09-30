module TypeProviders

open FSharp.Data
open Xunit
open System.IO
open System

[<Literal>]
let musicianJson = """ 
{   "firstName" : "Buddy", 
    "lastName" : "Holly", 
    "birthDate": "1926-10-18"   } """

type Musician = JsonProvider<musicianJson>

[<Fact>]
let ``1. single sample`` () = 

    // GetSample returns initialized value
    let musicianSample = Musician.GetSample()

    printfn "Musician: %A" musicianSample

    let daysSince (date:DateTime) = 
        DateTime.Now.Subtract(date).TotalDays

    daysSince musicianSample.BirthDate
    |> printfn "Days since birth: %f"

    0

[<Fact>]
let ``2. parse, load, construct`` () = 

    let newMusician = 
        new Musician.Root("Buddy", "Holly", DateTime.Now)

    let parsed = 
        Musician.Parse """{ 
            "firstName" : "Aretha", 
            "lastName" : "Franklin" }""" 

    parsed
    |> printfn "%A"

    // Several load options
    //Musician.Load ( new StringReader("{}") )
    //Musician.Load ( @"Module4\musicians.json" )
    //Musician.Load ( new FileStream( @"Module4\musicians.json", FileMode.Open))
    //Musician.Load ( "https://en.wikipedia.org/wiki/List_of_Rock_and_Roll_Hall_of_Fame_inductees")

    0

type musicians = JsonProvider<""" [ 
    { "FirstName" : "Elvis", "LastName" : "Presley", "FavoriteThing" : "abc" }, 
    { "FirstName" : "Little", "LastName" : "Richard", "FavoriteThing" : 3.14 } ] """>

[<Fact>]
let ``3. array sample`` () = 

    let musiciansSample = musicians.GetSamples()

    musiciansSample
    |> Seq.iter (fun sample ->     
        
        printfn "Musician: %A" sample
        
        match sample.FavoriteThing.Number, sample.FavoriteThing.String with 
        | Some number, _ -> printfn "Favorite Number: %A" number
        | _ , Some word -> printfn "Favorite Word: %A" word
        | _ -> printfn "Favorite is an unknown thing."
        
        )

