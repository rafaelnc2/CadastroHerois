namespace CadastroHerois.Api.Inputs.Heores;

public record UpdateHeroInput(string Name, string SecretName, int Age, string Universe)
{
    public int Id { get; private set; }
    public void SetId(int id)
    {
        Id = id;
    }
};