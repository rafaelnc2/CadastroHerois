using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface IUpdateHero
{
    Task<ApiDefaultOutput<UpdateHeroOutput>> ExecuteAsync(int Id, UpdateHeroInput input);
}