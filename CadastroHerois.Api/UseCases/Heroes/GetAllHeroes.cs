using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Heroes;

public class GetAllHeroes(IHeroRepository repository) : IGetAllHeroes
{
    public async Task<IEnumerable<GetHeroByIdOutput>> ExecuteAsync()
    {
        var heroes = await repository.GetAllAsync();
        
        var output = heroes
            .ToList()
            .ConvertAll(hero => new GetHeroByIdOutput(hero.Id, hero.Name, hero.SecretName, hero.Age, hero.Universe));

        return output;
    }
}