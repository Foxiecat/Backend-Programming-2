﻿using System.Linq.Expressions;

namespace StudentBloggAPI.Features.Common.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<T?> AddAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<T?> DeleteByIdAsync(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);
}