using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Entities;

//https://github.com/DapperLib/Dapper.Contrib

[Table ("Herois")]
public class Hero
{
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
    public DateTime CreateDate { get; private set; }
    public DateTime? UpdateDate { get; private set; }


    public static Hero Create(string name, string secretName, int age, string universe)
    {
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
        Name = name;
        SecretName = secretName;
        Age = age;
        Universe = universe;
        
        UpdateDate = DateTime.Now;
    }
}