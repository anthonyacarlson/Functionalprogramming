module Labs.Module3.DiscriminatedUnions

open FsUnit.Xunit
open Xunit

type Grade =
    | APlus 
    | A
    | AMinus
    | F
    
let grade score = failwith "You need to implement this function."

[<Fact>]
let ``100 should return A+`` () =
    grade 100 |> should equal APlus 

[<Fact(Skip = "Remove to run test")>]
let ``99 should return A`` () =
    grade 99 |> should equal A

[<Fact(Skip = "Remove to run test")>]
let ``93 should return A`` () =
    grade 93 |> should equal A
    
[<Fact(Skip = "Remove to run test")>]
let ``92 should return A-`` () =
    grade 92 |> should equal AMinus
    
[<Fact(Skip = "Remove to run test")>]
let ``90 should return A-`` () =
    grade 90 |> should equal AMinus
   
[<Fact(Skip = "Remove to run test")>]
let ``89 should return F`` () =
    grade 89 |> should equal F 
    
[<Fact(Skip = "Remove to run test")>]
let ``60 should return F`` () =
    grade 60 |> should equal F
    
[<Fact(Skip = "Remove to run test")>]
let ``0 should return F`` () =
    grade 0 |> should equal F 
