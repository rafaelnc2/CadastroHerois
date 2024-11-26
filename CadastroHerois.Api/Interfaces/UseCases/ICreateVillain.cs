using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface ICreateVillain
{
    Task<ApiDefaultOutput<int>> ExecuteAsync(CreateVillainInput input);
}