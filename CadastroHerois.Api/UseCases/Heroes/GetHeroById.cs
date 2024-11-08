using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Heroes;

public class GetHeroById(IHeroRepository repository) : IGetHeroById
{
    public async Task<ApiDefaultOutput<GetHeroByIdOutput>> ExecuteAsync(GetHeroByIdInput input)
    {
        var response = new ApiDefaultOutput<GetHeroByIdOutput>();
        
        var hero = await repository.GetByIdAsync(input.Id);

        if (hero is not Hero)
            return response.NotFoundResponse();
        
        var output = new GetHeroByIdOutput(hero.Id, hero.Name, hero.SecretName, hero.Age, hero.Universe);
        
        return response.OkResponse(output);
    }
}