using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface IGetHeroById
{
    Task<ApiDefaultOutput<GetHeroByIdOutput>> ExecuteAsync(GetHeroByIdInput input);
}