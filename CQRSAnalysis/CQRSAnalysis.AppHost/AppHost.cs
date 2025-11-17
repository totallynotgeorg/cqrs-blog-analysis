var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").AddDatabase("CQRSAnalysis");

builder.AddProject<Projects.CQRSAnalysis_API>("cqrsanalysis-api")
    .WithReference(postgres);

builder.Build().Run();
