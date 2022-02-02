#r "nuget:FSharp.Data"
#r "nuget:Npgsql.FSharp"

open Npgsql.FSharp

type Person = { Firstname:string ; Lastname:string option }

let connectionString  = "Host=localhost:5433;Database=EShop;Username=postgres;Password=admin"


let readPersons (connectionString: string) : Person list = 
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM person"
    |> Sql.execute (fun read -> 
        {
            Firstname = read.text "firstname"
            Lastname = read.textOrNone "lastname"
        })


let insertPerson (connectionString:string) = 
    connectionString
    |> Sql.connect
    |> Sql.prepare
