
using Transponder.Api.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// For this demo minimal api would be the simplest way, but the diagram calls for a VehicleController - so... ;)
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITransponderRepositoryFactory, TransponderRepositoryFactory>();
builder.Services.AddSingleton<ITransponderService, TransponderService>();
builder.Services.AddSingleton<IVehicleRepository, DummyVehicleRepository>();
// Here's why events are bad for DI and backend.
// We could register this as a singleton to improve performance and memory usage, but then we'll have multiple event subscriptions.
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Just in case it will be first tested in release mode ;)
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
