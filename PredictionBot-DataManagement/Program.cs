using Common.ErrorHandling.Middleware.Extensions;
using PredictionBot_DataManagement_Domain.Commons;
using PredictionBot_DataManagement_Domain.Configuration;
using PredictionBot_DataManagement_Infrastructure.Models.Configuration;
using PredictionBot_DataManagement_Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services configuration
builder.Services.Configure<TwelveDataConnection>(builder.Configuration.GetSection(Constant.ConfigurationSectionTwelveDataName));
builder.Services.Configure<DatabaseConnection>(builder.Configuration.GetSection(Constant.ConfigurationSectionDatabaseName));

builder.Services.AddInfrastructureServices();
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