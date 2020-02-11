# dotnetcore-fsharp-api
Playground for learning F# api best practices. My team is learning F# and the functional paradigm at the same time. We come from a C# background.

## Questions

Looking for feedback on file structure and module/type organization. I would like to do things the functional way, but it's hard to get out of the OO mindset. Once a good pattern is set up, it will make adding new endpoints easier. How would you structure an api that uses a database for some things and external api calls for other things, and where does the business logic layer fit in? I'll try to come up with more complicated endpoint examples. Also would like to find good patterns to replace how we are used to doing dependency injection in C#. One possibility that looks interesting is: https://dev.to/jhewlett/dependency-injection-in-f-web-apis-4h2o


## // TODO

Move weather stuff to Repositories and Domain files (instead of the client). Add mocks and stuff for saving things to the database. We use Postgres with our other Fsharp api.

Make a new enpoint that actually makes an external api call.
