namespace CadastroHerois.Api.Inputs.Villains;

public record UpdateVillainInput(string Name, string SecretName, int WhichHeroId, string Universe)
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }
};