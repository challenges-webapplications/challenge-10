using System;
using challenge_10.Shared.Domain.Repositories;
using challenge_10.Shared.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace challenge_10.Shared.Infrastructure.Persistence.Repositories;

public class BaseRepository<TEntity> : IbaseRepository<TEntity> where TEntity : class 
{
    protected readonly Challenge10Context Context;

    protected BaseRepository(Challenge10Context context)
    {
        Context = context;
    }

    /// <inheritdoc />
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        //dapper
    }

    /// <inheritdoc />
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    /// <inheritdoc />
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    /// <inheritdoc />
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}
