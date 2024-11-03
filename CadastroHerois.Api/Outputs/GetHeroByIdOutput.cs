namespace CadastroHerois.Api.Outputs;

public record GetHeroByIdOutput(int Id, string Name, string SecretName, int Age, string Universe);