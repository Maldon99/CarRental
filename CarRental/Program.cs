using CarRental.Interfaces;
using CarRental.Models;
using CarRental.Persintence;
using CarRental.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICarInventoryService, CarInventoryService>();

builder.Services.AddScoped<IRentalService, RentalService>();

builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddSingleton<InMemoryDbContext>(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
