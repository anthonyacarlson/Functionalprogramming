module Functions
open FsUnit
open Xunit

[<Fact(Skip = "Remove skip to run the test")>]
let ``Add function works`` () =
    // Write a function named add that adds two numbers together
    let sum = 0 //add 5 10
    sum |> should equal 15
  
[<Fact(Skip = "Remove skip to run the test")>]
let ``Sentence creator`` () =
    // Write a function named createSentence that takes two arguments and puts them into a sentence in the form of "a argOne is not a argTwo"
    let sentence = "" //createSentence "Dog" "Cat"
    sentence |> should equal "a Dog is not a Cat"
    
[<Fact(Skip = "Remove skip to run the test")>]
let ``Is question`` () =
    // Write a function named isQuestion that takes a string and returns a boolean to indicate if it contains a question mark
    let isQuestionOne = false //isQuestion "Is a dog a cat?"
    isQuestionOne |> should equal true
    
    let isQuestionTwo = true //isQuestion "A dog is a cat!"
    isQuestionTwo |> should equal false
