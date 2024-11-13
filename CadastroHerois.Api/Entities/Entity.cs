using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Entities;

public abstract class Entity
{
    protected static List<string> _errors = new();
    
    public IReadOnlyList<string> Errors() => _errors;
    
    public DateTime CreateDate { get; protected set; }
    public DateTime? UpdateDate { get; protected set; }
    
    [Computed]
    public bool IsValid
    {
        get => _errors.Any() is false;
    }
}