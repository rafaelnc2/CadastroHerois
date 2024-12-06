using CadastroHerois.Api.Entities;

namespace CadastroHerois.Api.Interfaces.Repositories;

public interface IBaseRepository<T> where T : Entity
{
    Task<int> SaveAsync(T entity);
    Task UpdateAsync(T entity);
    
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    
    Task DeleteAsync(T entity);
}