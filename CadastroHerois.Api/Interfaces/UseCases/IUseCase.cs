namespace CadastroHerois.Api.Interfaces.UseCases;

public interface IUseCase<in TInput, TOutput>
{
    Task<ApiDefaultOutput<TOutput>> ExecuteAsync(TInput input);
}