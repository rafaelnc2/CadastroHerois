namespace CadastroHerois.Api.Outputs.Villains;

public record UpdateVillainOutput(int Id, string Name, string SecretName, string WhichHeroName, string Universe, DateTime UpdatedAt);