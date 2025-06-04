using System;
using challenge_10.Operations.Domain;
using challenge_10.Operations.Domain.Models.Entities;
using challenge_10.Operations.Domain.Models.Queries;
using challenge_10.Operations.Domain.Services;

namespace challenge_10.Operations.Application.QueryServices;

public class OperationQueryService : IOperationQueryService
{
    private readonly IOperationsRepository _operationRepository;

    public OperationQueryService(IOperationsRepository operationsRepository)
    {
        _operationRepository = operationsRepository ?? throw new ArgumentNullException(nameof(operationsRepository));
    }

    public async Task<IEnumerable<Operation>> Handler(GetAllOperationsQuery query)
    {
        var operation = await _operationRepository.ListAsync();
        return operation?.Where(operation => operation.IsActive) ?? Enumerable.Empty<Operation>();
    }
}
