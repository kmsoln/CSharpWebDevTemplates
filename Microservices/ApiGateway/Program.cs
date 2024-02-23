using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region ConfigurationSetup
// Setting up the gateway map
var projectBath = builder.Environment.ContentRootPath;
builder.Configuration
    .SetBasePath($"{projectBath}/Routes")
    .AddJsonFile(path : "appsettings.json", optional: true, reloadOnChange: true)
    // AuthService
    .AddOcelot(folder: "Routes/AuthService", env: builder.Environment)
    // InfoService
    .AddOcelot(folder: "Routes/InfoService", env: builder.Environment)
    .AddEnvironmentVariables();

var gatewayConfigs = builder.Configuration;
builder.Services.AddOcelot(gatewayConfigs);

#endregion

var app = builder.Build();
// Ocelot gateway region
app.UseOcelot().Wait();

// Run the app
app.Run();