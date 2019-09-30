module MutabilityAnswers
open FsUnit
open Xunit

type Person = { mutable name: string }

let mutateName person newName =
    // FILL IN mutate the persons name to be the new name
    person.name <- newName 
    person

[<Fact(Skip = "Remove skip to run the test")>]
let ``Mutate field`` () =
    // Fill in the mutate name function to make the test pass
    let person = {name="Dr. Who"}
    mutateName person "Han Solo" |> ignore // piping a value to ignore will remove unused return value warnings.
    person.name |> should equal "Han Solo"
