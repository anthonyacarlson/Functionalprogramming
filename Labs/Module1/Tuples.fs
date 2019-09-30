module Tuples
open FsUnit
open Xunit

type Person = {firstName: string; lastName: string}

let tupleIsSameNumber (x: int, y: string) =
    x = (y |> int)

let pairHasDifferentValues (personOne, personTwo) =
    not (personOne = personTwo)

let tupleUp itemOne itemTwo =
    itemOne,itemTwo
    
[<Fact(Skip = "Remove skip to run the test")>]
let ``Tuple is same number`` () =
    // Pass a tuple to the tupleIsSameNumber function that evaluates to the same number when the string is parsed
    // tupleIsSameNumber createTupleHere |> should equal true
    0
    
[<Fact(Skip = "Remove skip to run the test")>]
let ``Pair has different values`` () =
    // Pass a tuple into the pairHasDifferentValues function with a person for you and your partner
    // pairHasDifferentValues createATupleOfPersonHere |> should equal true
    0
    
[<Fact(Skip = "Remove skip to run the test")>]
let ``Tuple return values equal`` () =
    let tuple = tupleUp "A" "A"
    // Assert that the first item in the tuple is equal to the second item in the tuple
    // firstItemInTupleHere |> should equal secondItemInTupleHere
    0
    
[<Fact(Skip = "Remove skip to run the test")>]
let ``Deconstruct tuples`` () =
    // Use the tupleUp function to create a tuple, and use deconstruction to create two different variables named first and second
    //let deconstructATupleHere = tupleUp "A" "A"
    //first |> should equal second
    0

[<Fact(Skip = "Remove skip to run the test")>]
let ``Third item out of tuple`` () =
    let tuple = (1,"a",5.0)
    // Create a variable named third that is the third item out of the tuple
    // let deconstructTheThirdItemHere = tuple
    //third |> should equal 5.0
    0