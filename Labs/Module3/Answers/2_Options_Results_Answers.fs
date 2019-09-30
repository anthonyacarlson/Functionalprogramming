module Labs.Module3.Answers.Options_Results_Answers

open System
open FsUnit.Xunit
open Xunit

let oneFor input : string =
    match input with
    | Some name -> sprintf "One for %s, one for me." name
    | None -> "One for you, one for me."
    
let validateInput (input: string option): Result<string, string> = 
    match input with
    | Some name ->
        match name with
        | invalidName when String.IsNullOrEmpty invalidName -> Error "Please enter a name"
        | _ -> Ok(oneFor input)
    | None -> Ok(oneFor input)
    