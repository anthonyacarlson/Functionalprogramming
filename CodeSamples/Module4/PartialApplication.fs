module PartialApplication

open System
open FSharp.Data
open System.Net
open FSharp.Data.HttpRequestHeaders
open Newtonsoft.Json
open Xunit
open FsUnit.Xunit
open FsUnit


[<Fact>]
let ``partial application`` () =


    // given this addition function
    // int -> int -> int
    let add a b = a + b

    // it can be called like this:
    let sum = add 1 2
    printfn "sum %i" sum

    // F# effectively creates this:
    // int -> int -> int
    let add a =
        let innerAdd b =
            a + b
        innerAdd

    // it can be called the same:
    let sum' = add 1 2

    printfn "add currying %i" <| add 1 2
    printfn "add currying %i" sum'

    // and it performs the same as:
    let sum' = ((add 1) 2)

    // and also performs the same as
    let add1 = add 1
    let sum'' = add1 2

    // int
    let sumWithCurrying = add(1)(2)

    // int -> int
    let addOnePartiallyApplied = add 1

    // int
    let sum' = addOnePartiallyApplied 2

    printfn "%i %A %i" sumWithCurrying addOnePartiallyApplied sum'








// Why/when would we want to do this?
// We can do this to hide implementation details when making use of high order funtions.


// Lets say we want to print a list of customers
// This is our customer
type Customer = { FirstName: string; LastName: string }


// We have this higher-order, function 
//   that creates a formatted list of customers.  
//(unit -> seq<Customer>) -> seq<string>
let formatCustomers getCustomers =
    
    // print as LastName, FirstName eg: Smith, John 
    let printFormat cust = sprintf "%s, %s" cust.LastName cust.FirstName

    getCustomers ()
    |> Seq.map printFormat

[<Fact>]
let ``format test`` () =
    let sampleCustomers () = seq [ 
        { FirstName = "John"; LastName = "Smith" };
        { FirstName = "Jane"; LastName = "Doe" } ] 
    let expected = seq [ "Smith, John"; "Doe, Jane" ]

    let result = formatCustomers sampleCustomers

    set result |> should equal (set expected)

[<Fact>]
let ``customer sample`` () = 


    

    // What is getCustomers though?  
    // It's anything that returns a list of customers

    // We could have many variations of getCustomers with their own implementation details.

    // SQL Database
    let getCustomersFromDatabase connectionString =
        // Open SQL DB
        // Read customers
        // Map DB format to our type
        // Return customers
        seq [ { FirstName = "John"; LastName = "Smith" } ]

    // we can partially apply some parameters 
    //   to make it compatible with our list formatter
    let dbCustomers () = 
        getCustomersFromDatabase "server=...;catalog=..."

    printfn "%A" dbCustomers
    
    formatCustomers dbCustomers
    |> Seq.iter (printfn "%A")
    



    // Or perhaps we need to call CIV

    let getCivCustomer url mcGruffAuthHeader fcsaAuditHeader =
        // Create HttpClient
        // Create Http Request with headers
        // Enhance URL to call CIV V8
        // Call CIV to get customers
        // Map CIV format to our type
        seq [ { FirstName = "John"; LastName = "Smith" } ]

    let civCustomers () = 
        getCivCustomer "https://fcsamerica.com/custinfovault..." "SAML ..." "{ Partner... }"

    formatCustomers civCustomers
    |> Seq.iter (printfn "%A")



// What is the C# parallel implementation?  
// Interfaces, concrete objects with constructor parameters.  
// What SOLID principles come into play?  Easily SID.  
// This has Dependency Inversion and Interface Segregation at its purest form, at the function level.  
// What would it be like to code C# so that every interface only had 1 function?


// Partial Application is one of the premier features for using a functional language.






























//
// Less compelling sample follows...
//




//
// More complex samples
//

let customerSearch url authHeader fcsaAudit nameFilter zipCodeFilter =

    // Call an API that looks like this:  https://custinfovault.fcsamerica.com/customersearch?nameFilter=Jane&zipCodeFilter=68105
    //let response = 
    //    Http.Request ( 
    //        url, 
    //        headers = [ 
    //            Accept HttpContentTypes.Json; 
    //            Authorization authHeader; 
    //            ("FCSA-Audit", fcsaAudit) ],
    //        query = [
    //            ("nameFilter", nameFilter); 
    //            ("zipCodeFilter", zipCodeFilter) ],
    //        httpMethod = "GET")

    //match response.Body with
    //| Text t -> JsonConvert.DeserializeObject<Customer array>(t)
    //| Binary _ -> failwith "Binary Http Result unexpected"

    match zipCodeFilter with
    | "68105" -> [{ FirstName = "Chuck"; LastName = "Berry" }; { FirstName = "James"; LastName = "Brown" }]
    | "68127" -> [{ FirstName = "Ray"; LastName = "Charles" }; { FirstName = "Sam"; LastName = "Cooke" }]
    | "68164" -> [{ FirstName = "Don"; LastName = "Everly" }; { FirstName = "Phil"; LastName = "Everly" }]
    | _ -> []



// If I wanted to print all found customers names in upper case then I might have something like this
let printCustomers customersToPrint = 
    customersToPrint
        |> Seq.map (fun cust -> cust.FirstName)
        |> Seq.map (fun name -> name.ToUpper())
        |> Seq.iter (fun name -> printfn "%s" name)



//I want to print the names for 3 different zip codes

let zipCodes = ["68105"; "68127"; "68164"]


// option 1a - not realistic, but demonstrates the point of calling search 3 times
customerSearch "https://custinfovault.fcsamerica.com/customersearch" "mcgruff auth header" "fcsa-audit header" "all names" "68105"
    |> printCustomers
customerSearch "https://custinfovault.fcsamerica.com/customersearch" "mcgruff auth header" "fcsa-audit header" "all names" "68127"
    |> printCustomers
customerSearch "https://custinfovault.fcsamerica.com/customersearch" "mcgruff auth header" "fcsa-audit header" "all names" "68164"
    |> printCustomers
    


// option 1b
// better, but any other calls to customer search will have all parameters specified even though the first 3 parameters are static
zipCodes 
    |> Seq.map (fun zipCode -> customerSearch "https://custinfovault.fcsamerica.com/customersearch" "mcgruff auth header" "fcsa-audit header" "all names" zipCode)
    |> Seq.iter printCustomers



// option 2 with partial application
let configuredSearch = customerSearch "https://custinfovault.fcsamerica.com/customersearch" "mcgruff auth header" "fcsa-audit header" 
// customerSearch   has a signature of string -> string -> string -> string -> string -> Customer array
// configuredSearch has a signature of                               string -> string -> Customer array    In C# it would look like this:  Customer[] ConfiguredSearch(string nameFilter, string zipCodeFilter) { }


configuredSearch "all names" "68105"
    |> printCustomers

configuredSearch "all names" "68127"
    |> printCustomers

configuredSearch "all names" "68164"
    |> printCustomers
    


// option 3 - applying a list partial
zipCodes 
    |> Seq.map (configuredSearch "all names") // <- This creates an even more constrained partially applied function on the fly.  Partial application makes it easier to fit the signature of map.
    |> Seq.iter printCustomers













// What if we wanted to customize the print
let customPrintCustomers selector alteration customersToPrint = 
    customersToPrint
        |> Seq.map selector 
        |> Seq.map alteration 
        |> Seq.iter (fun name -> printfn "%s" name)


let lastNamePrint =
    customPrintCustomers (fun cust -> cust.LastName) (fun name -> name.ToLower())

zipCodes
    |> Seq.map (configuredSearch "all names")
    |> Seq.iter lastNamePrint //(customPrintCustomers (fun cust -> cust.LastName))





// since F# defaults to generics when it can, this custom variation goes from Customer to int and then to string
let lastNameLengthPrint =
    customPrintCustomers (fun cust -> cust.LastName.Length) (fun length -> length.ToString())

zipCodes
    |> Seq.map (configuredSearch "all names")
    |> Seq.iter lastNameLengthPrint //(customPrintCustomers (fun cust -> cust.LastName))


// Are all these layers of functional abstraction necessary or even desired?  MOST LIKELY NOT!!  The point is that F# makes it easy to create these abstractions with the ceremony of creating concrete interfaces and classes




//let dump text = printfn "%s" text

//[<Fact>]
//let ``dump customers`` () = 
//    do dump "text"
    
[<Fact>]
let ``run sample`` () = 
    zipCodes 
    |> Seq.map (configuredSearch "all names") // <- This creates an even more constrained partially applied function on the fly.  Partial application makes it easier to fit the signature of map.
    |> Seq.iter printCustomers
