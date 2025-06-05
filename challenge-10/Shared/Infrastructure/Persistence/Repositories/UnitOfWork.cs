using System;
using challenge_10.Shared.Domain;
using challenge_10.Shared.Domain.Repositories;
using challenge_10.Shared.Infrastructure.Persistence.Configuration;

namespace challenge_10.Shared.Infrastructure.Persistence.Repositories;

public class UnitOfWork(Challenge10Context context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}
