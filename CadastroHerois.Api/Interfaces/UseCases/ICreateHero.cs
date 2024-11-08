using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface ICreateHero
{
    Task<ApiDefaultOutput<int>> ExecuteAsync(CreateHeroInput input);
}