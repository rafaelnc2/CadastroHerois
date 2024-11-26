using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Vilains;

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