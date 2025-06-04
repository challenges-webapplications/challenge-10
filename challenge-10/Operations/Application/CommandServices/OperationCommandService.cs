using System.Data;
using challenge_10.Operations.Domain;
using challenge_10.Operations.Domain.Models.Commands;
using challenge_10.Operations.Domain.Models.Entities;
using challenge_10.Operations.Domain.Services;
using challenge_10.Operations.Infrastructure;
using challenge_10.Shared.Domain.Repositories;

namespace challenge_10.Operations.Application.CommandServices;

public class OperationCommandService(IOperationsRepository operationRepository, IUnitOfWork unitOfWork) : IOperationCommandService
{
    private readonly IOperationsRepository _operationRepository = operationRepository ?? throw new ArgumentNullException(nameof(operationRepository));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<Operation> Handler(CreateOperationCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        var operations = await _operationRepository.ListAsync();
        if (operations.Any(operation => operation.Name == command.Name))
            throw new DuplicateNameException($"A book with the name '{command.Name}' already exists.");
        var operation = new Operation(command.Name, command.Description, command.Completed, command.CompletedDate)
        {
            UserId = 1
        };
        await _operationRepository.AddAsync(operation);
        await _unitOfWork.CompleteAsync();
        return operation;
    }

    public async Task<bool> Handler(DeleteOperation command)
    {
        ArgumentNullException.ThrowIfNull(command);
        var operation = await _operationRepository.FindByIdAsync(command.Id);
        if (operation is null) return false;
        operation.IsActive = false;
        operation.ModifiedDate = DateTime.UtcNow;
        operation.UpdatedUserId = 87;
        _operationRepository.Update(operation);
        await _unitOfWork.CompleteAsync();
        return true;
        
    }

}
