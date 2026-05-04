using Tarefinhas.Data;
using Tarefinhas.Routes;

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.getTarefinhasRoutes();

app.Run();