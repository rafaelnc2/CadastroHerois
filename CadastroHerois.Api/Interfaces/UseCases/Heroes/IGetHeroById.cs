using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Inputs.Heores;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Heroes;

namespace CadastroHerois.Api.Interfaces.UseCases.Heroes;

public interface IGetHeroById : IUseCase<GetHeroByIdInput, GetHeroByIdOutput>
{
}