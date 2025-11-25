using Scalar.AspNetCore;

using Microsoft.EntityFrameworkCore;
using Hongsa.Rtms.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Entity Framework Core MS SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Scalar API Reference Configuration
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Hongsa RTMS API (Scalar)")
            .WithTheme(ScalarTheme.Laserwave) // light, dark, purple
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });


}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
