namespace CadastroHerois.Api.Outputs;

public record UpdateHeroOutput(int Id, string Name, string SecretName, int Age, string Universe, DateTime UpdatedAt);