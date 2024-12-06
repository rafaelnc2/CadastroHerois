using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Inputs.Heores;
using CadastroHerois.Api.Interfaces.UseCases;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Heroes;

namespace CadastroHerois.Api.Interfaces;

public interface IUpdateHero: IUseCase<UpdateHeroInput, UpdateHeroOutput>
{
}