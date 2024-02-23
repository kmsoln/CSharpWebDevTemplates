using InfoService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices
// Configure services for the application
builder.Services.AddControllers(); // Add MVC controllers
builder.Services.AddEndpointsApiExplorer(); // Add API Explorer for endpoints
builder.Services.AddSwaggerGen(); // Add Swagger for API documentation
#endregion

#region ConfigureDatabase

string connectionString = builder.Configuration.GetConnectionString("MyDatabase") ?? "";

builder.Services.AddDbContext<CustomDbContext>(o =>
{
    o.UseNpgsql(connectionString);
});

#endregion

// Build the application
var app = builder.Build();

#region ConfigurePipeline
// Configure the HTTP request pipeline.

// If the application is in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger middleware
    app.UseSwaggerUI(); // Enable Swagger UI for interactive documentation
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS

app.MapControllers(); // Map controllers for handling requests

#endregion

// Run the application
app.Run();