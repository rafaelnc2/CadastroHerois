using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;

namespace CadastroHerois.Api.UseCases.Heroes;

public class CreateHero(IHeroRepository repository) : ICreateHero
{
    public async Task<int> ExecuteAsync(CreateHeroInput input)
    {
        var hero = Hero.Create(input.Name, input.SecretName, input.Age, input.Universe);

        var insertedId = await repository.SaveAsync(hero);
        
        return insertedId;
    }
}