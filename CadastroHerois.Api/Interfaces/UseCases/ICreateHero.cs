using CadastroHerois.Api.Inputs;

namespace CadastroHerois.Api.Interfaces;

public interface ICreateHero
{
    Task<int> ExecuteAsync(CreateHeroInput input);
}