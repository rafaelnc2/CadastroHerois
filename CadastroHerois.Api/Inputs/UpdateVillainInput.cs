namespace CadastroHerois.Api.Inputs;

public record UpdateVillainInput(int id, string Name, string SecretName, int WhichHeroId, string Universe);