using PersonRestAPI.Models;
using PersonRestAPI.Repositories.Interfaces;

namespace PersonRestAPI.Endpoints;

public static class PersonEndpoints
{
    public static void MapPersonEndpoints(this WebApplication app)
    {
        var personGroup = app.MapGroup("/persons");
        
        personGroup.MapGet("", GetPersons)
            .WithName("GetPersons")
            .WithOpenApi();

        personGroup.MapPost("", AddPerson)
            .WithName("AddPerson")
            .WithOpenApi();

        personGroup.MapDelete("/{id:int}", DeletePerson)
            .WithName("DeletePerson")
            .WithOpenApi();
        
        personGroup.MapPut("{id:int}", UpdatePersonAsync)
            .WithName("UpdatePerson")
            .WithOpenApi();
    }


    private static async Task<IResult> GetPersons(IPersonRepository repository)
    {
        // Retrieve from the database
        return Results.Ok(await repository.GetAllAsync());
    }

    private static async Task<IResult> AddPerson(IPersonRepository repository, Person person)
    {
        Person? addPerson = await repository.AddAsync(person);
        
        // Add to the database
        return addPerson is null
            ? Results.BadRequest("Fail to add database")
            : Results.Ok(addPerson);
    }

    private static async Task<IResult> DeletePerson(IPersonRepository repository, int id)
    {
        Person? deletePerson = await repository.DeleteAsync(id);
        
        return deletePerson is null
            ? Results.BadRequest($"Fail to delete person with {id} database")
            : Results.Ok(deletePerson);
    }

    private static async Task<IResult> UpdatePersonAsync(IPersonRepository repository, int id, Person person)
    {
        Person? updatePerson = await repository.UpdateAsync(id, person);
        
        return updatePerson is null
            ? Results.BadRequest($"Failed to update {person} in database")
            : Results.Ok(updatePerson);
    }
}