using MelodyHub.Application;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.Interfaces;
using MelodyHub.Database;
using MelodyHub.WebApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IMelodyHubDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<MelodyHubDbContext>();
Console.WriteLine(context.Materials);

DbContextInitializer.Initialize(context);

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("FrontendPolicy");
app.MapControllers();

app.Run();
