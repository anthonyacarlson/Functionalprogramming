module ListOpsTestSolutions

open FsUnit.Xunit
open Xunit

[<Fact>]
let ``Create a list containing all elements within given range 3 to 13`` () =
    let list1 = [3..13]
    list1 |> should equal [3;4;5;6;7;8;9;10;11;12;13]

[<Fact>]
let ``append non-empty lists`` () =
    let list1 = [1; 2];
    let list2 = [2; 3; 4; 5]; 
    let appendedList = List.append list1 list2  
    appendedList|> should equal [1; 2; 2; 3; 4; 5]


[<Fact>]
let ``find last element of list`` () =
    let list1 = [1; 2; 3; 4; 5; 6] 
    let revList = List.rev list1
    let last = List.head revList
    last |> should equal 6

[<Fact>]
let ``find last but one element of list`` () =
    let list1 = [1; 2; 3; 4; 5; 6] 
    let revList = List.rev list1
    let tail = List.tail revList
    let lastButOne = List.head tail
    lastButOne |> should equal 5


/// A palindrome can be read forward or backward; e.g. (x a m a x).
[<Fact>]
let ``Find if the given list is a palindrome`` () =
    let list1 = ["m"; "a"; "d"; "a"; "m"] 
    let revList = List.rev list1
    list1 |> should equal revList

[<Fact>]
let ``filter numbers that are greater than 5`` () =
    let numbers = [1;3;6;8;9;0;87;54;34;57]
    let result = List.filter (fun x -> x>5) numbers
    result |> should equal [6;8;9;87;54;34;57]

[<Fact>]
let ``sort lists`` () =
    let numbers = [1;3;6;8;9;0;87;54;34;57]
    let result = List.sort numbers
    result.Head |> should equal 0

[<Fact>]
let ``sort lists by length`` () =
    let animals = ["Cat"; "Dog"; "Lion"; "Tiger"; "Giraffee"; "Horse"; "Goat"]
    let result = animals |> List.sortBy (fun (word:string) -> word.Length)
    result.Head |> should equal "Cat"

[<Fact>]
let ``Add all list elements`` () =
    let numbers = [1;3;6;8;9;0;87;54;34;57]
    let result = List.sum numbers
    result |> should equal 259

[<Fact>]
let ``Duplicate elements in a given list`` () =
    let lista = [1;2;3;4];
    let dupli = List.map(fun d -> [d;d]) lista;
    let res = List.concat dupli;
    res |> should equal [1;1;2;2;3;3;4;4];
