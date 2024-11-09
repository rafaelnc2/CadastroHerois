using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Entities;

public abstract class Entity
{
    protected static List<string> _errors = new();
    
    public IReadOnlyList<string> Errors() => _errors;
    
    [Computed]
    public bool IsValid
    {
        get => _errors.Any() is false;
    }
}