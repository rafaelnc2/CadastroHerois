using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces.Repositories;

public interface IVillainRepository : IBaseRepository<Villain>
{
    Task<IEnumerable<GetVillainByIdOutput>> GetAllVillainsAsync();
}