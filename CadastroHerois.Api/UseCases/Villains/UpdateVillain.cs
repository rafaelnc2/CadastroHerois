using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Vilains;

public sealed class UpdateVillain(IVillainRepository repository, IHeroRepository heroRepository) : IUpdateVillain
{
    public async Task<ApiDefaultOutput<UpdateVillainOutput>> ExecuteAsync(int id, UpdateVillainInput input)
    {
        var response = new ApiDefaultOutput<UpdateVillainOutput>();

        var whichHero = await heroRepository.GetByIdAsync(input.WhichHeroId);
        
        if(whichHero is null)
            return response.BadRequestResponse(["Invalid Hero Id"]);
        
        var vilain = await repository.GetByIdAsync(id);
        
        if(vilain is null)
            return response.NotFoundResponse();
        
        vilain.Update(input.Name, input.SecretName, input.WhichHeroId, input.Universe);

        if (vilain.IsValid is false)
            return response.BadRequestResponse(vilain.Errors());
        
        await repository.UpdateAsync(vilain);
        
        var output = new UpdateVillainOutput(vilain.Id, vilain.Name, vilain.SecretName, whichHero.Name, vilain.Universe, vilain.UpdateDate!.Value);

        return response.OkResponse(output);
    }
}