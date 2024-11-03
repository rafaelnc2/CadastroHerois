using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface IGetHeroById
{
    Task<GetHeroByIdOutput> ExecuteAsync(GetHeroByIdInput input);
}