using System.Data.Common;
using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetEntityBySpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetAllBySpecAsync(ISpecification<T> spec);
    Task<IReadOnlyList<TResult>> GetAllBySpecAsync<TResult>(ISpecification<T, TResult> spec);
    Task<TResult?> GetEntityBySpec<TResult>(ISpecification<T, TResult> spec);
    Task<T?> GetByIdAsync(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    bool Exist(int id);
    Task<bool> SaveAllAsync();
    Task<int> CountAsync(ISpecification<T> spec);
}