using System;
using challenge_10.Operations.Domain.Models.Commands;
using challenge_10.Operations.Domain.Models.Entities;

namespace challenge_10.Operations.Domain.Services;

public interface IOperationCommandService
{
    Task<Operation> Handler(CreateOperationCommand command);
    Task<bool> Handler(DeleteOperation comamnd);
}
