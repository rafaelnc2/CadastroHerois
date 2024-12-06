using CadastroHerois.Api.Inputs.Villains;

namespace CadastroHerois.Api.Interfaces.UseCases.Villains;

public interface ICreateVillain : IUseCase<CreateVillainInput, int>
{
}