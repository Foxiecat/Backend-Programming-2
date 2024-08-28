using PersonRestAPI.Models;
using PersonRestAPI.Repositories.Interfaces;

namespace PersonRestAPI.Repositories;

public class PersonInMemoryDataStorage : IPersonRepository
{
    private static readonly List<Person> DataBaseInMemoryStorage = [];
    
    
    public async Task<Person?> AddAsync(Person person)
    {
        await Task.Delay(10);
        
        // Adding to a list
        person.id = DataBaseInMemoryStorage.Count + 1;
        DataBaseInMemoryStorage.Add(person);
        return person;
    }

    public async Task<ICollection<Person>> GetAllAsync()
    {
        await Task.Delay(10);
        
        // Retrieve all from a list
        return DataBaseInMemoryStorage;
    }

    public async Task<Person?> DeleteAsync(int id)
    {
        await Task.Delay(10);

        // Delete person with specified ID
        Person? personToRemove = DataBaseInMemoryStorage.Find(person => person.id == id);
        
        if (personToRemove != null)
            DataBaseInMemoryStorage.Remove(personToRemove);
        
        return personToRemove;
    }

    public async Task<Person?> UpdateAsync(int id, Person person)
    {
        await Task.Delay(10);

        // Update person with specified ID
        Person? personToUpdate = DataBaseInMemoryStorage.Find(p => p.id == id);
        
        if (personToUpdate is null)
            return null;
        
        personToUpdate.FirstName = person.FirstName;
        personToUpdate.LastName = person.LastName;
        personToUpdate.Age = person.Age;
        
        return personToUpdate;
    }
}