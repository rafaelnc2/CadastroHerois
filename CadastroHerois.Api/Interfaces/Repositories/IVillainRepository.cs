using CadastroHerois.Api.Outputs.Villains;

namespace CadastroHerois.Api.Interfaces.Repositories;

public interface IVillainRepository : IBaseRepository<Villain>
{
    Task<IEnumerable<GetVillainByIdOutput>> GetAllVillainsAsync();
}