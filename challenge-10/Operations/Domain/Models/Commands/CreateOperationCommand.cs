namespace challenge_10.Operations.Domain.Models.Commands;

public record CreateOperationCommand(string Name, string Description, bool Completed, DateTime CompletedDate)
{

}
