using System;
using challenge_10.Operations.Domain.Models.Entities;
using challenge_10.Shared.Domain.Repositories;

namespace challenge_10.Operations.Domain;

public interface IOperationsRepository : IbaseRepository<Operation>
{

}
