using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CadastroHerois.Api.UseCases.Heroes;

public class GetAllHeroes(IHeroRepository repository) : IGetAllHeroes
{
    public async Task<ApiDefaultOutput<IEnumerable<GetHeroByIdOutput>>> ExecuteAsync()
    {
        var response = new ApiDefaultOutput<IEnumerable<GetHeroByIdOutput>>();
        
        var heroes = await repository.GetAllAsync();
        
        var output = heroes
            .ToList()
            .ConvertAll(hero => new GetHeroByIdOutput(hero.Id, hero.Name, hero.SecretName, hero.Age, hero.Universe));

        return response.OkResponse(output);
    }
}