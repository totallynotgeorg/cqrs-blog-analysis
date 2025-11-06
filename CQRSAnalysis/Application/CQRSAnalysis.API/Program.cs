using CQRSAnalyse.WolverineHttp;
using CQRSAnalysis.BrighterDarker;
using CQRSAnalysis.CQRSlite;
using CQRSAnalysis.MassTransit;
using CQRSAnalysis.MediatR;
using CQRSAnalysis.Services;
using CQRSAnalysis.Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);

// builder.Host.AddWolverineServices();
builder.Host.AddWolverineHttpServices();

builder.Services.AddBrighterDarkerServices();
builder.Services.AddCQRSliteServices();
builder.Services.AddMediatRServices(builder.Configuration.GetValue<string>("LicenseKey"));
builder.Services.AddMassTransitServices();
builder.Services.AddBusinessLogic();
builder.Services.AddWolverineHttp();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.MapWolverineEndpoints();

app.UseHttpsRedirection();

app.RegisterHandlers();

app.Run();