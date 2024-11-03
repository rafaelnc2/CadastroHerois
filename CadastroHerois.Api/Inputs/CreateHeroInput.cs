namespace CadastroHerois.Api.Inputs;

public record CreateHeroInput(string Name, string SecretName, int Age, string Universe);