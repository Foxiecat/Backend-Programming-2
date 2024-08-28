using PersonRestAPI.Endpoints;
using PersonRestAPI.Repositories;
using PersonRestAPI.Repositories.Interfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPersonRepository, PersonInMemoryDataStorage>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Write our own endpoint! Method: GET, https://localhost:7288/persons/

app.MapPersonEndpoints(); // It's really important to keep our code clean

app.Run();