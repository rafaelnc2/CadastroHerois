namespace CadastroHerois.Api.Outputs;

public record GetVillainByIdOutput(int Id, string Name, string SecretName, string WhichHeroName, string Universe);