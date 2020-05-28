# Stuff - a veritable cornucopia of wonderful things you can do with F# and ASP.NET Core web API

Requires .NET 5 preview, though you may be able to change the TFM to `netcoreapp3.1`. Just `dotnet run` it!

Some key characteristics of F# here:

* Files are explicitly listed in _dependency order_ in the project file
* F# async is `Async<'T>` and you will need to use either `Async.AwaitTask` or `Async.StartAsTask` to interop with .NET `Task<'T>`

Some things I did not show:

* F# code in modules
* F# type providers and other F# features
* Using F# with non-Microsoft frameworks
* F# as a console app
* Web apps via Fable, Bolero, SAFE

Definitely check these things out!
