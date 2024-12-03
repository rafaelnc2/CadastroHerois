using System.Data;
using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Interfaces.Repositories;
using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Infra.Repositories;

public class HeroRepository : BaseRepository<Hero>, IHeroRepository
{
    public HeroRepository(IDbConnection connection) : base(connection)
    {
        
    }
}