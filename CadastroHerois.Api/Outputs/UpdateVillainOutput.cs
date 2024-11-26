namespace CadastroHerois.Api.Outputs;

public record UpdateVillainOutput(int Id, string Name, string SecretName, string WhichHeroName, string Universe, DateTime UpdatedAt);