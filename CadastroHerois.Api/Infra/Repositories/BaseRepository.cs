using Dapper.Contrib.Extensions;

namespace CadastroHerois.Api.Infra.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    protected readonly IDbConnection _connection;

    protected BaseRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public Task<int> SaveAsync(T entity)
    {
        return _connection.InsertAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        return _connection.UpdateAsync(entity);
    }

    public Task<T> GetByIdAsync(int id)
    {
        return _connection.GetAsync<T>(id);
    }

    public virtual Task<IEnumerable<T>> GetAllAsync()
    {
        return _connection.GetAllAsync<T>();
    }

    public Task DeleteAsync(T entity)
    {
        return _connection.DeleteAsync(entity);
    }
}