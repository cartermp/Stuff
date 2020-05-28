namespace Stuff.Controllers

open System
open System.Collections.Generic
open System.Linq
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Stuff

[<ApiController>]
[<Route("[controller]")>]
type PigLatinController (logger : ILogger<PigLatinController>) =
    inherit ControllerBase()

    // Phillip --> hillipPay
    // Apple --> Appleyay

    let vowels = set ['A'; 'a'; 'E'; 'e'; 'I'; 'i'; 'O'; 'o'; 'U'; 'u']

    let toPigLatin (str: string) =
        let firstChar = str.[0]
        if vowels.Contains(firstChar) then
            str + "yay"
        else
            str.[1..] + string firstChar + "ay"

    [<HttpGet>]
    member __.Get(str: string) =
        if (String.IsNullOrWhiteSpace(str)) then
            {| Name = "nothing"; PigLatinName = "nothing" |}
        else
            {| Name = str; PigLatinName = toPigLatin str |}
