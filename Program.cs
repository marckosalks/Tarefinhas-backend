using Tarefinhas.Data;
using Tarefinhas.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;


var builder = WebApplication.CreateBuilder(args);

// adicionar plitica de cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaRegraDeCors",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }

    );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TarefinhasContext>();

var app = builder.Build();

app.UseCors("MinhaRegraDeCors");

app.UseSwagger();
app.UseSwaggerUI();

app.getTarefinhasRoutes();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TarefinhasContext>();
    db.Database.EnsureCreated();
}

app.Run();