namespace CadastroHerois.Api.Inputs.Villains;

public record CreateVillainInput(string Name, string SecretName, int WhichHeroId, string Universe);