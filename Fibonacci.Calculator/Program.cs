using EasyNetQ;
using Fibonacci.Calculator.Domain.Models.Aggregates;
using Fibonacci.Calculator.Infrastructure.Services;
using Gateway.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsDefault();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IFibonacciService, FibonacciService>();
builder.Services.RegisterEasyNetQ("host=localhost", register => register.EnableMicrosoftLogging());


var app = builder.Build();

app.UseRouting();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fibonacci}/{action=Calculate}");


app.Run();


