using Backend.Core.Application;
using Backend.Infra.Persistence;
using Backend.Presentation.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.ConfigureApplicationApp();
builder.Services.ConfigurePersistenceApp(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
