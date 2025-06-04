using System;
using challenge_10.Operations.Domain;
using challenge_10.Operations.Domain.Models.Entities;
using challenge_10.Shared.Infrastructure.Persistence.Configuration;
using challenge_10.Shared.Infrastructure.Persistence.Repositories;

namespace challenge_10.Operations.Infrastructure;

public class OperationRepository(Challenge10Context context) : BaseRepository<Operation>(context), IOperationsRepository
{

}
