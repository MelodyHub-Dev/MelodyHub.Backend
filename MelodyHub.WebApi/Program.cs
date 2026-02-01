using MelodyHub.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseCustomExceptionHandler();

app.Run();
