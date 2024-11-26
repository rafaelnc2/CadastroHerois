using System.Runtime.InteropServices.JavaScript;
using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Entities;

//https://github.com/DapperLib/Dapper.Contrib

[Table ("Heroes")]
public class Hero : Entity
{
    private const int NameMinLength = 3;
    private const int NameMaxLength = 50;
    
    private Hero(int id, string name, string secretName, int age, string universe, DateTime createDate, DateTime? updateDate)
    {
        Id = id;
        Name = name;
        SecretName = secretName;
        Age = age;
        Universe = universe;
        CreateDate = createDate;
        UpdateDate = updateDate;
    }
    
    [Key]
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string SecretName { get; private set; }
    public int Age { get; private set; }
    public string Universe { get; private set; }


    private static void Validate(string name, string secretName, int age, string universe)
    {
        _errors.Clear();
        
        if (string.IsNullOrWhiteSpace(name) || name.Length < NameMinLength || name.Length > NameMaxLength)
            _errors.Add("Name is invalid");
        
        if (string.IsNullOrWhiteSpace(secretName) || secretName.Length < NameMinLength || secretName.Length > NameMaxLength)
            _errors.Add("Secret Name is invalid");
        
        if (age == 0)
            _errors.Add("Age is invalid");
        
        if (string.IsNullOrWhiteSpace(universe))
            _errors.Add("Universe is invalid");
    }
    
    public static Hero? Create(string name, string secretName, int age, string universe)
    {
        Validate(name, secretName, age, universe);

        if (_errors.Any())
            return null;
        
        var hero = new Hero(
            id: 0,
            name: name,
            secretName: secretName,
            age: age,
            universe: universe,
            createDate: DateTime.Now,
            updateDate: null
        );
        
        return hero;
    }

    public void Update(string name, string secretName, int age, string universe)
    {
        Validate(name, secretName, age, universe);

        if (IsValid is false)
            return;
        
        Name = name;
        SecretName = secretName;
        Age = age;
        Universe = universe;
        
        UpdateDate = DateTime.Now;
    }
}