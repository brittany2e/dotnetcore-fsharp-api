namespace FSharpApi

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy;
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.OpenApi.Models
open FSharpApi.News
open FSharpApi.WeatherForecast


type Startup private () =

    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration
        this.ConnectionString <- "<Not write :/>"

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddControllers() |> ignore
        
        services.AddSwaggerGen(fun c ->
            c.SwaggerDoc("v1", OpenApiInfo())
         ) |> ignore

        services.AddScoped<News.DataAccess.IDataAccess>(fun _ -> News.DataAccess.getInstance (this.ConnectionString)) |> ignore
        services.AddScoped<WeatherForecast.DataAccess.IDataAccess>(fun _ -> WeatherForecast.DataAccess.getInstance (this.ConnectionString)) |> ignore
        

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseRouting() |> ignore

        app.UseAuthorization() |> ignore

        app.UseSwagger() |> ignore

        app.UseSwaggerUI(fun c ->
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnet Fsharp API")
            ) |> ignore

        app.UseEndpoints(fun endpoints ->
            endpoints.MapControllers() |> ignore
            ) |> ignore

    member val Configuration : IConfiguration = null with get, set
    member val ConnectionString : string = null with get, set