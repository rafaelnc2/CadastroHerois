using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Inputs.Villains;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Interfaces.UseCases.Villains;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Villains;

public sealed class CreateVillain(IVillainRepository repository, IHeroRepository heroRepository) : ICreateVillain
{
    public async Task<ApiDefaultOutput<int>>  ExecuteAsync(CreateVillainInput input)
    {
        var response = new ApiDefaultOutput<int>();

        var whichHeroBelongs = await heroRepository.GetByIdAsync(input.WhichHeroId);

        if (whichHeroBelongs is not Hero)
            return response.BadRequestResponse(["Heroi informado não é válido"]);
        
        var villain = Villain.Create(input.Name, input.SecretName, input.WhichHeroId, input.Universe);

        if (villain?.IsValid is false)
            return response.BadRequestResponse(villain.Errors());
        
        var insertedId = await repository.SaveAsync(villain!);
        
        return response.CreatedResponse(insertedId);
    }
}