namespace CadastroHerois.Api.Outputs.Villains;

public record GetVillainByIdOutput(int Id, string Name, string SecretName, string WhichHeroName, string Universe);