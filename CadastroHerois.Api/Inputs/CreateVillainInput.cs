namespace CadastroHerois.Api.Inputs;

public record CreateVillainInput(string Name, string SecretName, int WhichHeroId, string Universe);