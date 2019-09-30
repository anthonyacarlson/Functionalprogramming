module PartialApplicationAnswerLab

open FsUnit.Xunit
open Xunit
open System
open System.Text.RegularExpressions


let dataProcessor ``process`` data =
    // do not change this function
    data 
    |> List.map ``process`` 



// Exercise 1 - enhance
// Create an enhance function that can concatenate a message to a name
let enhance message name =
    sprintf "%s %s" name message

// Create a mutate partial function that supplies 'is awesome!' as the first parameter
let enhancePartial : string -> string = 
    enhance "is awesome!"

[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 1. - enhance`` () =
    enhance "is awesome!" "Jimmy" |> should equal "Jimmy is awesome!"


[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 1. - process with partial`` () =
    let result = dataProcessor enhancePartial ["John"; "Jill"; "Joan"; "Jack"]

    result |> should equal ["John is awesome!"; "Jill is awesome!"; "Joan is awesome!"; "Jack is awesome!"]




// Exercise 2 - sensitive info filter
// Create a log function that uses Regex.Replace to replace sensitive data with --redacted--
let log regex message =
    Regex.Replace(message, regex, "--redacted--")

// Create a mutate function that upper cases data.
let mutate (message : string) = 
    message.ToUpper()

// Create a log partial method that uses the regex "\d\d/\d\d/\d\d\d\d" to redact sensitive date data.  
let logPartial = 
    log "\d\d/\d\d/\d\d\d\d"

// Create a mutateAndLog function that mutates and redacts sensitive data
let mutateAndLog message = 
    message |> mutate |> logPartial



[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 2. - log `` () =
    log "\d\d" "42" |> should equal "--redacted--"


[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 2. - sensitive info filter`` () =
    logPartial "Billy was born 12/03/1945" |> should equal "Billy was born --redacted--"


[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 2. - mutate`` () =
    mutate "Billy" |> should equal "BILLY"


[<Fact(Skip = "Remove skip to run the test")>]
let ``Exercise 2. - mutate and log`` () =
    let result = dataProcessor mutateAndLog ["John was born 12/03/1945"; "Jill was born 05/13/1975"; "Joan was born 03/06/1963"; "Jack was born 10/26/1942"]

    result |> should equal ["JOHN WAS BORN --redacted--"; "JILL WAS BORN --redacted--"; "JOAN WAS BORN --redacted--"; "JACK WAS BORN --redacted--"]
