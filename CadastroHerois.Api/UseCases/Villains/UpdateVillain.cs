using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Inputs.Villains;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Interfaces.UseCases.Villains;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Villains;

namespace CadastroHerois.Api.UseCases.Villains;

public sealed class UpdateVillain(IVillainRepository repository, IHeroRepository heroRepository) : IUpdateVillain
{
    public async Task<ApiDefaultOutput<UpdateVillainOutput>> ExecuteAsync(UpdateVillainInput input)
    {
        var response = new ApiDefaultOutput<UpdateVillainOutput>();

        var whichHero = await heroRepository.GetByIdAsync(input.WhichHeroId);
        
        if(whichHero is null)
            return response.BadRequestResponse(["Invalid Hero Id"]);
        
        var villain = await repository.GetByIdAsync(input.Id);
        
        if(villain is null)
            return response.NotFoundResponse();
        
        villain.Update(input.Name, input.SecretName, input.WhichHeroId, input.Universe);

        if (villain.IsValid is false)
            return response.BadRequestResponse(villain.Errors());
        
        await repository.UpdateAsync(villain);
        
        var output = new UpdateVillainOutput(villain.Id, villain.Name, villain.SecretName, whichHero.Name, villain.Universe, villain.UpdateDate!.Value);

        return response.OkResponse(output);
    }
}