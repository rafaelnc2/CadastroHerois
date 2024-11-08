using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Heroes;

public class UpdateHero(IHeroRepository repository) : IUpdateHero
{
    public async Task<UpdateHeroOutput> ExecuteAsync(int id, UpdateHeroInput input)
    {
        var hero = await repository.GetByIdAsync(id);
        
        hero.Update(input.Name, input.SecretName, input.Age, input.Universe);

        await repository.UpdateAsync(hero);
        
        var output = new UpdateHeroOutput(hero.Id, hero.Name, hero.SecretName, hero.Age, hero.Universe, hero.UpdateDate!.Value);

        return output;
    }
}