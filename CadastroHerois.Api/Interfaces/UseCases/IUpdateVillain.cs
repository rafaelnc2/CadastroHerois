using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Outputs;

namespace CadastroHerois.Api.Interfaces;

public interface IUpdateVillain
{
    Task<ApiDefaultOutput<UpdateVillainOutput>> ExecuteAsync(int id, UpdateVillainInput input);
}