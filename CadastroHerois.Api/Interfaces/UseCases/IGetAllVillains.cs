using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface IGetAllVillains
{
    Task<ApiDefaultOutput<IEnumerable<GetVillainByIdOutput>>> ExecuteAsync();
}