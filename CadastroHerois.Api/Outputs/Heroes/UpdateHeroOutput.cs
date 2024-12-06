namespace CadastroHerois.Api.Outputs.Heroes;

public record UpdateHeroOutput(int Id, string Name, string SecretName, int Age, string Universe, DateTime UpdatedAt);