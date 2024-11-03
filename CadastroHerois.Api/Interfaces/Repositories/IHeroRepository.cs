using CadastroHerois.Api.Entities;

namespace CadastroHerois.Api.Interfaces.Repositories;

public interface IHeroRepository
{
    Task<int> SaveAsync(Hero hero);
    Task UpdateAsync(Hero hero);
    
    Task<Hero> GetByIdAsync(int id);
    Task<IEnumerable<Hero>> GetAllAsync();
    
    Task DeleteAsync(int id);
}