namespace CadastroHerois.Api.Outputs.Heroes;

public record GetHeroByIdOutput(int Id, string Name, string SecretName, int Age, string Universe);