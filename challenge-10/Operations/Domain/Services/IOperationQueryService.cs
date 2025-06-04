using System;
using challenge_10.Operations.Domain.Models.Entities;
using challenge_10.Operations.Domain.Models.Queries;

namespace challenge_10.Operations.Domain.Services;

public interface IOperationQueryService
{
    Task<IEnumerable<Operation>> Handler(GetAllOperationsQuery query);
    Task<Operation?> Handler(GetOperationByIdQuery query);
}
