using PersonRestAPI.Models;
using PersonRestAPI.Repositories.Interfaces;

namespace PersonRestAPI.Repositories;

public class PersonGenericInMemoryDataBase : IRepository<Person>
{
    public Task<Person?> AddAsync(Person data)
    {
        throw new NotImplementedException();
    }

    public Task<Person?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Person>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Person?> UpdateAsync(Person data)
    {
        throw new NotImplementedException();
    }

    public Task<Person?> DeleteAsync(Person data)
    {
        throw new NotImplementedException();
    }

    public Task<Person?> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}