namespace CadastroHerois.Api.Entities;

public class Vilain : Entity
{
    private const int NameMinLength = 3;
    private const int NameMaxLength = 50;
    
    private Vilain(int id, string name, string secretName, int whichHeroId, string universe, DateTime createDate, DateTime? updateDate)
    {
        Id = id;
        Name = name;
        SecretName = secretName;
        WhichHeroId = whichHeroId;
        Universe = universe;
        
        CreateDate = createDate;
        UpdateDate = updateDate;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string SecretName { get; private set; }
    public int WhichHeroId { get; private set; }
    public string Universe { get; private set; }

    private static void Validate(string name, string secretName, int whichHeroId, string universe)
    {
        _errors.Clear();
        
        if (string.IsNullOrWhiteSpace(name) || name.Length < NameMinLength || name.Length > NameMaxLength)
            _errors.Add("Name is invalid");
        
        if (string.IsNullOrWhiteSpace(secretName) || secretName.Length < NameMinLength || secretName.Length > NameMaxLength)
            _errors.Add("Secret Name is invalid");
        
        if (whichHeroId == 0)
            _errors.Add("Tell us which hero this villain belongs to");
        
        if (string.IsNullOrWhiteSpace(universe))
            _errors.Add("Universe is invalid");
    }
    
    public static Vilain? Create(string name, string secretName, int whichHeroId, string universe)
    {
        Validate(name, secretName, whichHeroId, universe);

        if (_errors.Any())
            return null;
        
        var vilain = new Vilain(
            id: 0,
            name: name, 
            secretName: secretName,
            whichHeroId: whichHeroId, 
            universe: universe,
            createDate: DateTime.Now,
            updateDate: null
        );
        
        return vilain;
    }

    public void Update(string name, string secretName, int whichHeroId, string universe)
    {
        Validate(name, secretName, whichHeroId, universe);

        if (IsValid is false)
            return;
        
        Name = name;
        SecretName = secretName;
        WhichHeroId = whichHeroId;
        Universe = universe;
        UpdateDate = DateTime.Now;
    }
}