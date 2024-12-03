using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Vilains;

public sealed class GetAllVillains(IVillainRepository repository, IHeroRepository heroRepository) : IGetAllVillains
{
    public async Task<ApiDefaultOutput<IEnumerable<GetVillainByIdOutput>>> ExecuteAsync()
    {
        var response = new ApiDefaultOutput<IEnumerable<GetVillainByIdOutput>>();
        
        var villains = await repository.GetAllVillainsAsync();

        return response.OkResponse(villains);
    }
}