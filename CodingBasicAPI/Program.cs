using CodingBasicAPI.Data;
using CodingBasicAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configures services to support API controllersI.
builder.Services.AddControllers();

// Configures services to support API exploration
builder.Services.AddEndpointsApiExplorer();

// Configures services to generate Swagger documentation
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdventureWorks2019Context>(Options => 
        Options.UseSqlServer(builder.Configuration.GetConnectionString("localServer")));

builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SaleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enables HTTP to HTTPS redirection for enhanced security
app.UseHttpsRedirection();

// Maps controllers to routes, enabling routing for API endpoints
app.MapControllers();

// Enables authorization middleware to handle access control based on policies
app.UseAuthorization();

app.MapGet("/", () => @"Hello World");
app.Run();

