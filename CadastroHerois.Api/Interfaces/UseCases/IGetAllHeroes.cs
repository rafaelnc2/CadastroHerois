using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface IGetAllHeroes
{
    Task<ApiDefaultOutput<IEnumerable<GetHeroByIdOutput>>> ExecuteAsync();
}