using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Inputs.Heores;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Heroes;

namespace CadastroHerois.Api.UseCases.Heroes;

public sealed class UpdateHero(IHeroRepository repository) : IUpdateHero
{
    public async Task<ApiDefaultOutput<UpdateHeroOutput>> ExecuteAsync(UpdateHeroInput input)
    {
        var response = new ApiDefaultOutput<UpdateHeroOutput>();
        
        var hero = await repository.GetByIdAsync(input.Id);
        
        hero.Update(input.Name, input.SecretName, input.Age, input.Universe);

        if (hero.IsValid is false)
            return response.BadRequestResponse(hero.Errors());
        
        await repository.UpdateAsync(hero);
        
        var output = new UpdateHeroOutput(hero.Id, hero.Name, hero.SecretName, hero.Age, hero.Universe, hero.UpdateDate!.Value);

        return response.OkResponse(output);
    }
}