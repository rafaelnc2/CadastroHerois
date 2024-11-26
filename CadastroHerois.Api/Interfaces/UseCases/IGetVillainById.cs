using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface IGetVillainById
{
    Task<ApiDefaultOutput<GetVillainByIdOutput>> ExecuteAsync(GetVillainByIdInput input);
}