var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithEndpoint(port: 5432, targetPort: 51674, name: "postgres")
    .AddDatabase("CQRSAnalysis");

builder.AddProject<Projects.CQRSAnalysis_API>("cqrsanalysis-api")
    .WaitFor(postgres)
    .WithReference(postgres);

builder.Build().Run();
