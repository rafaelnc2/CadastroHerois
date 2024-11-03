namespace CadastroHerois.Api.Interfaces;

public interface IUseCase
{
    Task ExecuteAsync<T>(T input);
}