module Labs.Module3.Options

open FsUnit.Xunit
open Xunit


let oneFor (input: string option): string = failwith "You need to implement this function."

let validateInput (input: string option): Result<string, string> = failwith "You need to implement this function."

[<Fact>]
let ``No name given`` () =
    oneFor None |> should equal "One for you, one for me."

[<Fact(Skip = "Remove to run test")>]
let ``A name given`` () =
    oneFor (Some "Alice") |> should equal "One for Alice, one for me."

[<Fact(Skip = "Remove to run test")>]
let ``Another name given`` () =
    oneFor (Some "Bob") |> should equal "One for Bob, one for me."
    
[<Fact(Skip = "Remove to run test")>]
let ``validateInput with empty string given, returns Error`` () =
    let result = validateInput (Some "")
    
    //Assert
    match result with
    | Error res -> res |> should equal "Please enter a name"
    | _ -> failwith "Result didn't match"
    
[<Fact(Skip = "Remove to run test")>]
let ``validateInput with a name given, returns ok with oneFor return`` () =
    let result = validateInput (Some "Bob")
    
    //Assert
    match result with
    | Ok res -> res |> should equal "One for Bob, one for me."
    | _ -> failwith "Result didn't match"
    
[<Fact(Skip = "Remove to run test")>]
let ``validateInput with no name given, returns ok with oneFor return`` () =
    let result = validateInput None
    
    //Assert
    match result with
    | Ok res -> res |> should equal "One for you, one for me."
    | _ -> failwith "Result didn't match"
    