using System.Formats.Asn1;

namespace PersonRestAPI.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> AddAsync(T data);
    Task<T?> GetByIdAsync(int id);
    Task<ICollection<T>> GetAllAsync();
    Task<T?> UpdateAsync(T data);
    Task<T?> DeleteAsync(T data);
    Task<T?> DeleteByIdAsync(int id);
}