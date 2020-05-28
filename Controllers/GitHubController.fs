namespace Stuff.Controllers

open System
open System.Collections.Generic
open System.Linq
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Stuff
open Octokit

[<ApiController>]
[<Route("[controller]")>]
type GitHubController (logger : ILogger<GitHubController>) =
    inherit ControllerBase()

    let githubUsers (uname: string) =
        async {
            let github = GitHubClient(ProductHeaderValue("MyAmazingApp"))
            let! user = github.User.Get(uname) |> Async.AwaitTask
            return user.Followers
        }

    [<HttpGet>]
    member _.Get(uname: string) =
        async {
            if (String.IsNullOrEmpty(uname)) then
                return {| Name = "nothing"; Followers = 0 |}
            else
                let! followers = githubUsers uname
                return {| Name = uname; Followers = followers |}
        }
