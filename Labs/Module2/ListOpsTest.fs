module ListOpsTest

open FsUnit.Xunit
open Xunit

[<Fact(Skip = "Remove skip to run the test")>]
let ``Create a list containing all elements within given range 3 to 13`` () =
    let list1 = [];// create your list here
    list1 |> should equal [3;4;5;6;7;8;9;10;11;12;13]

    
[<Fact(Skip = "Remove skip to run the test")>]
let ``append list1 and list2 together`` () =
    let list1 = [1; 2];
    let list2 = [2; 3; 4; 5]; 
    let appendedList = [];
    appendedList|> should equal [1; 2; 2; 3; 4; 5]


[<Fact(Skip = "Remove skip to run the test")>]
let ``find last element of list`` () =
    let list1 = [1; 2; 3; 4; 5; 6] 
    let lastElem = 0
    lastElem |> should equal 6


[<Fact(Skip = "Remove skip to run the test")>]
let ``find last but one element of list`` () =
    let list1 = [1; 2; 3; 4; 5; 6] 
    let lastButOne = 0
    lastButOne |> should equal 5


/// A palindrome can be read forward or backward; e.g. (x a m a x).
[<Fact(Skip = "Remove skip to run the test")>]
let ``Find if the given list is a palindrome`` () =
    let list1 = ["m"; "a"; "d"; "a"; "m"] 
    let revList = []
    list1 |> should equal revList

    
[<Fact(Skip = "Remove skip to run the test")>]
let ``filter numbers that are greater than 5`` () =
    let numbers = [1;3;6;8;9;0;87;54;34;57]
    let result = []
    result |> should equal [6;8;9;87;54;34;57]


[<Fact(Skip = "Remove skip to run the test")>]
let ``sort lists`` () =
    let numbers = [1;3;6;8;9;0;87;54;34;57]
    let result = []
    result.Head |> should equal 0


[<Fact(Skip = "Remove skip to run the test")>]
let ``sort lists by length`` () =
    let animals = ["Cat"; "Dog"; "Lion"; "Tiger"; "Giraffee"; "Horse"; "Goat"]
    let result = []
    result.Head |> should equal "Cat"


[<Fact(Skip = "Remove skip to run the test")>]
let ``Add all list elements`` () =
    let numbers = [1;3;6;8;9;0;87;54;34;57]
    let result = []
    result |> should equal 259


[<Fact(Skip = "Remove skip to run the test")>]
let ``Duplicate elements in a given list`` () =
    let lista = [1;2;3;4];
    let res = []
    res |> should equal [1;1;2;2;3;3;4;4];

