using System;
using challenge_10.Operations.Domain.Models.Entities;
using challenge_10.Operations.Interfaces.REST.Resource;

namespace challenge_10.Operations.Interfaces.REST.Transform;

public static class OperationResourceFromEntityAssembler
{
    public static OperationResource ToResourceFromEntity(Operation operation)
    {
        return new OperationResource(operation.Id, operation.Name, operation.Description, operation.Completed);
    }
}
