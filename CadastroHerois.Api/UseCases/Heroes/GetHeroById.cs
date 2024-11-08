using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Heroes;

public class GetHeroById(IHeroRepository repository) : IGetHeroById
{
    public async Task<GetHeroByIdOutput> ExecuteAsync(GetHeroByIdInput input)
    {
        var hero = await repository.GetByIdAsync(input.Id);

        var output = new GetHeroByIdOutput(hero.Id, hero.Name, hero.SecretName, hero.Age, hero.Universe);
        
        return output;
    }
}