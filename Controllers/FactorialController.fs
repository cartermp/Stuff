namespace Stuff.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Stuff

[<ApiController>]
[<Route("[controller]")>]
type FactorialController (logger : ILogger<FactorialController>) =
    inherit ControllerBase()

    let rec factorial n =
        match n with
        | 0
        | 1 -> 1
        | _ ->
            n * factorial (n-1)

    [<HttpGet>]
    member __.Get(x: int) =
        sprintf "The factorial of %d is %d" x (factorial x)
