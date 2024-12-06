using CadastroHerois.Api.Inputs.Heores;
using CadastroHerois.Api.Interfaces.UseCases.Heroes;

namespace CadastroHerois.Api.UseCases.Heroes;

public sealed class CreateHero(IHeroRepository repository) : ICreateHero
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