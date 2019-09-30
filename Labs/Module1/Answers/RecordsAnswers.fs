module RecordsAnswers
open FsUnit
open Xunit

type Employee = {employeeName: string}
type Customer = {name: string; id: int; isGoodPerson: bool}

[<Fact(Skip = "Remove skip to run the test")>]
let ``Create customer named Joe, has an id of 1337, and is not a good person`` () =
    let customer = {name="Joe";id=1337;isGoodPerson=false}
    customer.name |> should equal "Joe"
    customer.id |> should equal 1337
    customer.isGoodPerson |> should equal false
    0
    
type EmployeeFavorite = {employee: Employee;favoriteCandy: string}

[<Fact(Skip = "Remove skip to run the test")>]
let ``Create a type to contain an employee and their favoriteCandy`` () =
    let employeesFavorite = { employee={employeeName="Joe"}; favoriteCandy="Cotton Candy"} 
    employeesFavorite.employee.employeeName |> should equal "Joe"
    employeesFavorite.favoriteCandy |> should equal "Cotton Candy"
    0
