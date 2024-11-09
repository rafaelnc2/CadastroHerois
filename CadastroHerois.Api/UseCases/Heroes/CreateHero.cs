using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Heroes;

public class CreateHero(IHeroRepository repository) : ICreateHero
{
    public async Task<ApiDefaultOutput<int>> ExecuteAsync(CreateHeroInput input)
    {
        var response = new ApiDefaultOutput<int>();
        
        var hero = Hero.Create(input.Name, input.SecretName, input.Age, input.Universe);

        if (hero?.IsValid is false)
            return response.BadRequestResponse(hero.Errors());
        
        var insertedId = await repository.SaveAsync(hero!);
        
        return response.CreatedResponse(insertedId);
    }
}