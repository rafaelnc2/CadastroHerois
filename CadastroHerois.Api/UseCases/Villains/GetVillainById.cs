using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Inputs.Villains;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Interfaces.UseCases.Villains;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Villains;

namespace CadastroHerois.Api.UseCases.Villains;

public sealed class GetVillainById(IVillainRepository repository, IHeroRepository heroRepository) : IGetVillainById
{
    public async Task<ApiDefaultOutput<GetVillainByIdOutput>> ExecuteAsync(GetVillainByIdInput input)
    {
        var response = new ApiDefaultOutput<GetVillainByIdOutput>();

        var vilain = await repository.GetByIdAsync(input.Id);
        
        if(vilain is null)
            return response.NotFoundResponse();
        
        var whichHero = await heroRepository.GetByIdAsync(vilain.WhichHeroId);
        
        var output = new GetVillainByIdOutput(vilain.Id, vilain.Name, vilain.SecretName, whichHero.Name, vilain.Universe);
        
        return response.OkResponse(output);
    }
}