using System.Security.Cryptography;
using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Outputs;
using CadastroHerois.Api.Outputs.Heroes;

namespace CadastroHerois.Api.Interfaces.UseCases.Heroes;

public interface IGetAllHeroes : IUseCase<Unit, IEnumerable<GetHeroByIdOutput>>
{

}