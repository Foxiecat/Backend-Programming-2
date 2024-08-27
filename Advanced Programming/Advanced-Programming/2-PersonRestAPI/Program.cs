using _2_PersonRestAPI.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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

// Lager vårt første endepunkt! Metode: GET, https://localhost:7288/persons/

app.MapGet(pattern:"/persons", handler:() =>
    {
        Person person = new() { Age = 20, id = 1, FirstName = "Ola", LastName = "Normann" };
        return Results.Ok(person); 
    }).WithName("GetPersons")
    .WithOpenApi();

app.MapPost(pattern:"/persons", handler:(Person person) =>
{
    return Results.Ok(new Person()
    {
        Age = person.Age + 1,
        FirstName = person.FirstName,
        LastName = person.LastName,
        id = person.id,
    });
}).WithName("AddPerson")
    .WithOpenApi();

app.Run();