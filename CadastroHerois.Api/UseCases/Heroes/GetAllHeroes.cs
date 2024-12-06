using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Interfaces.UseCases.Heroes;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Heroes;

namespace CadastroHerois.Api.UseCases.Heroes;

public sealed class GetAllHeroes(IHeroRepository repository) : IGetAllHeroes
{
    public async Task<ApiDefaultOutput<IEnumerable<GetHeroByIdOutput>>> ExecuteAsync(Unit input)
    {
        var response = new ApiDefaultOutput<IEnumerable<GetHeroByIdOutput>>();
        
        var heroes = await repository.GetAllAsync();
        
        var output = heroes
            .ToList()
            .ConvertAll(hero => new GetHeroByIdOutput(hero.Id, hero.Name, hero.SecretName, hero.Age, hero.Universe));

        return response.OkResponse(output);
    }
}