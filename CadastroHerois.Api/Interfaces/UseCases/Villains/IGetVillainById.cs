using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Inputs.Villains;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Villains;

namespace CadastroHerois.Api.Interfaces.UseCases.Villains;

public interface IGetVillainById : IUseCase<GetVillainByIdInput, GetVillainByIdOutput>
{
}