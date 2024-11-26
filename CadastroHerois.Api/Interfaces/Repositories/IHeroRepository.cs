using CadastroHerois.Api.Entities;

namespace CadastroHerois.Api.Interfaces.Repositories;

public interface IHeroRepository
{
    Task<int> SaveAsync(Hero entity);
    Task UpdateAsync(Hero entity);
    
    Task<Hero> GetByIdAsync(int id);
    Task<IEnumerable<Hero>> GetAllAsync();
    
    Task DeleteAsync(Hero entity);
}