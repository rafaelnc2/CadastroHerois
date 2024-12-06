using CadastroHerois.Api.Interfaces.UseCases.Villains;
using CadastroHerois.Api.Outputs.Villains;

namespace CadastroHerois.Api.UseCases.Villains;

public sealed class GetAllVillains(IVillainRepository repository, IHeroRepository heroRepository) : IGetAllVillains
{
    public async Task<ApiDefaultOutput<IEnumerable<GetVillainByIdOutput>>> ExecuteAsync(Unit input)
    {
        var response = new ApiDefaultOutput<IEnumerable<GetVillainByIdOutput>>();
        
        var villains = await repository.GetAllVillainsAsync();

        return response.OkResponse(villains);
    }
}