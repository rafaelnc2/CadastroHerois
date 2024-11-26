using System.Data;
using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Interfaces.Repositories;
using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Infra.Repositories;

public class HeroRepository : IHeroRepository
{
    private readonly IDbConnection _connection;

    public HeroRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task<int> SaveAsync(Hero hero)
    {
        return _connection.InsertAsync(hero);
    }

    public Task UpdateAsync(Hero hero)
    {
        return _connection.UpdateAsync(hero);
    }

    public Task<Hero> GetByIdAsync(int id)
    {
        return _connection.GetAsync<Hero>(id);
    }

    public Task<IEnumerable<Hero>> GetAllAsync()
    {
        return _connection.GetAllAsync<Hero>();
    }

    public Task DeleteAsync(Hero hero)
    {
        return _connection.DeleteAsync(hero);
    }
}