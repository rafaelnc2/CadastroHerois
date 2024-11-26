using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.UseCases.Vilains;

public sealed class CreateVillain(IVillainRepository repository) : ICreateVillain
{
    public async Task<ApiDefaultOutput<int>>  ExecuteAsync(CreateVillainInput input)
    {
        var response = new ApiDefaultOutput<int>();
        
        var villain = Villain.Create(input.Name, input.SecretName, input.WhichHeroId, input.Universe);

        if (villain?.IsValid is false)
            return response.BadRequestResponse(villain.Errors());
        
        var insertedId = await repository.SaveAsync(villain!);
        
        return response.CreatedResponse(insertedId);
    }
}