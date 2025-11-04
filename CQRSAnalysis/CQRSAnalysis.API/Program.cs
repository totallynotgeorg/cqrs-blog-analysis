using CQRSAnalysis.MassTransit;
using CQRSAnalysis.MediatR;
using CQRSAnalysis.Services;
using CQRSAnalysis.Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddWolverineServices();

builder.Services.AddMediatRServices();
builder.Services.AddMassTransitServices();
builder.Services.AddBusinessLogic();

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

app.UseHttpsRedirection();

app.Run();