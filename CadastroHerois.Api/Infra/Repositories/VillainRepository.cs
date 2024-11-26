using System.Data;
using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;
using Dapper;
using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Infra.Repositories;

public class VillainRepository : IVillainRepository
{
    private readonly IDbConnection _connection;

    public VillainRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task<int> SaveAsync(Villain entity)
    {
        return _connection.InsertAsync(entity);
    }

    public Task UpdateAsync(Villain entity)
    {
        return _connection.UpdateAsync(entity);
    }

    public Task<Villain> GetByIdAsync(int id)
    {
        return _connection.GetAsync<Villain>(id);
    }

    public async Task<IEnumerable<GetVillainByIdOutput>> GetAllAsync()
    {
        var sql = """
                    SELECT  vl.Id, 
                            vl.Name, 
                            vl.SecretName, 
                            h.Name as WhichHeroName, 
                            vl.Universe
                    FROM    Villains as vl
                                inner join 
                            Heroes as h
                                on vl.WhichHeroId = h.Id
                  """;

        var result = await _connection.QueryAsync<GetVillainByIdOutput>(sql);

        return result;
    }
    
    public Task DeleteAsync(Villain entity)
    {
        return _connection.DeleteAsync(entity);
    }
}