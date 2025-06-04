
namespace challenge_10.Shared.Domain.Repositories;

public interface IbaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);

    Task<TEntity?> FindByIdAsync(int id);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    Task<IEnumerable<TEntity>> ListAsync();
}
