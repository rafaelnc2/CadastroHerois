using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Inputs.Heores;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Interfaces.UseCases.Heroes;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Heroes;

namespace CadastroHerois.Api.UseCases.Heroes;

public sealed class GetHeroById(IHeroRepository repository) : IGetHeroById
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