module JsonTypeProviderAnswerLab

open FSharp.Data
open Xunit
open FsUnit.Xunit

[<Literal>]
let musicianJson = """ [ 
    { "firstName" : "Elvis", "lastName" : "Presley", "inductionYear" : 1986 }, 
    { "firstName" : "Aretha", "lastName" : "Franklin", "inductionYear" : 1987 },
    { "firstName" : "Whitney", "lastName" : "Houston" },
    { "bandName" : "The Beatles", "inductionYear" : 1988 }] """


// Exercise 1
// Create a type load the musicianJson
type musicians = JsonProvider<musicianJson>

// Create a function to return the number of musicians
let musicianSampleCount (musicians : 'a array ) = 
    musicians.Length


[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 1. - Load json`` () =

    let samples = musicians.GetSamples()
    musicianSampleCount samples |> should be (greaterThan 1)
    

// Exercise 2
// Create a function that returns years since induction report per Exercise 2 test
// HINT: musicians.Root is the type of an individual musician
let yearsSinceInductionReport (musicians : musicians.Root array) =

    let printLine (musician : musicians.Root) =
        let yearsSince = 
            match musician.InductionYear with
            | Some year -> Some <| System.DateTime.Now.Year - year 
            | None -> None

        let name (musician : musicians.Root) =
            match musician.FirstName, musician.LastName, musician.BandName with
            | Some first, Some last, Some band -> sprintf "%s %s of %s" first last band
            | Some first, Some last, None -> sprintf "%s %s" first last
            | None , Some single, Some band -> sprintf "%s of %s" single band
            | Some single , None , Some band -> sprintf "%s of %s" single band
            | None , Some single, None -> sprintf "%s" single 
            | Some single , None , None -> sprintf "%s" single 
            | None, None, Some band -> sprintf "%s" band
            | None, None, None -> sprintf "data error" 

        match yearsSince with
        | Some years -> sprintf "%s was inducted %i years ago" (name musician) years
        | None -> sprintf "%s has not been inducted" (name musician)

    musicians
    |> Array.map printLine

[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 2. - Type inference proof`` () =

// Prove that JsonProvider properly inferred inductionYear as an integer
//      by verifying the number of years since induction is correct.

    let samples = 
        musicians.GetSamples()
        |> Array.take 2
    let result = yearsSinceInductionReport samples

    let expected = [|"Elvis Presley was inducted 33 years ago"; "Aretha Franklin was inducted 32 years ago"|]
    
    result |> should equal expected


[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 3. - Experiment - person not inducted`` () =

// What happens when you add a person not inducted? Whitney Houston perhaps -> ,{ "firstName" : "Whitney", "lastName" : "Houston" }
// What data type is inductionYear?  
// Can you still produce a meaningful report? Discuss with your partner, code it if you have time.

    let samples = 
        musicians.GetSamples()
    let result = yearsSinceInductionReport samples

    printfn "%A" result

[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 4. - Experiment - band name inductee`` () =

// What happens when the inductee is a band? -> ,{ "bandName" : "The Beatles", "inductionYear" : 1988 }
// What adustments need to be made to account for this?
// Can you still produce a meaningful report? Discuss with your partner, code it if you have time.

    let samples = 
        musicians.GetSamples()
    let result = yearsSinceInductionReport samples

    printfn "%A" result
