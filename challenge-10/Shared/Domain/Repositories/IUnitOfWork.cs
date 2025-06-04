using System;

namespace challenge_10.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
