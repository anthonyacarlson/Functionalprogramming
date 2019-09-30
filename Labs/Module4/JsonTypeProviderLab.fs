module JsonTypeProviderLab

open FSharp.Data
open Xunit
open FsUnit.Xunit

[<Literal>]
let musicianJson = """ [ 
    { "firstName" : "Elvis", "lastName" : "Presley", "inductionYear" : 1986 }, 
    { "firstName" : "Aretha", "lastName" : "Franklin", "inductionYear" : 1987 } ] """


// Exercise 1
// Create a type load the musicianJson
type musicians = JsonProvider<musicianJson>

// Create a function to return the number of musicians
let musicianSampleCount (musicians : musicians.Root array) = 
    0


[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 1. - Load json`` () =

    let samples = musicians.GetSamples()
    musicianSampleCount samples |> should be (greaterThan 1)
    


// Exercise 2
// Create a function that returns years since induction report per the Exercise 2 test
// HINT: musicians.Root is the type of an individual musician
let yearsSinceInductionReport (musicians : musicians.Root array) =
    [||]


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
