using CadastroHerois.Api.Outputs.Villains;

namespace CadastroHerois.Api.Interfaces.UseCases.Villains;

public interface IGetAllVillains : IUseCase<Unit, IEnumerable<GetVillainByIdOutput>>
{
}