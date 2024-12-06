namespace CadastroHerois.Api.Infra.Repositories;

public class HeroRepository : BaseRepository<Hero>, IHeroRepository
{
    public HeroRepository(IDbConnection connection) : base(connection)
    {
        
    }
}