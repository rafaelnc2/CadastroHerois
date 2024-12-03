using System.Data;
using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;
using Dapper;
using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Infra.Repositories;

public class VillainRepository : BaseRepository<Villain>, IVillainRepository
{
    public VillainRepository(IDbConnection connection) : base(connection)
    {
        
    }

    public async Task<IEnumerable<GetVillainByIdOutput>> GetAllVillainsAsync()
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

}