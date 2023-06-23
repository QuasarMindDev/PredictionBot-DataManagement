using Common.ErrorHandling.Middleware.Extensions;
using DataModuleInfrastructure.Models;
using PredictionBot_DataManagement_Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<TwelveDataConnection>(builder.Configuration.GetSection("TwelveData"));
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddGlobalMiddleware();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGlobalMiddleware();

app.MapControllers();

app.Run();