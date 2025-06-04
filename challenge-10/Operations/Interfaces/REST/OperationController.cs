using System.Data;
using challenge_10.Operations.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using challenge_10.Operations.Domain.Models.Queries;
using challenge_10.Operations.Interfaces.REST.Transform;
using challenge_10.Operations.Domain.Models.Commands;
using NuGet.Common;

namespace challenge_10.Operations.Interfaces.REST;

[Route("api/[controller]")]
[ApiController]
public class OperationController : ControllerBase
{
    private readonly IOperationQueryService _operationQueryService;
    private readonly IOperationCommandService _operationCommandService;
    public OperationController(IOperationQueryService operationQueryService, IOperationCommandService operationCommandService)
    {
        _operationQueryService = operationQueryService ?? throw new ArgumentNullException(nameof(operationQueryService));
        _operationCommandService = operationCommandService ?? throw new ArgumentNullException(nameof(operationCommandService));
    }
    public async Task<IActionResult> GetAsync()
    {
        var query = new GetAllOperationsQuery();
        var result = await _operationQueryService.Handler(query);
        if (!result.Any()) return NotFound("No Operations Found.");
        var resources = result.Select(OperationResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateOperationCommand command)
    {
        if (command.CompletedDate > DateTime.UtcNow)
        {
            throw new InvalidOperationException("La fecha no concuerda.");
        }
        if (command == null) return BadRequest("invalid Operation");
        try
        {
            await _operationCommandService.Handler(command);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (DuplicateNameException)
        {
            return Conflict("An operation witht the same name was found.");
        }
        catch (Exception ex)
        {
            return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0) return BadRequest("invalid id");
         var getOperationQuery = new GetOperationByIdQuery(id);
        var operation = await _operationQueryService.Handler(getOperationQuery);
        var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
            if (operation?.CompletedDate > thirtyDaysAgo)
            {
                return BadRequest("Solo se pueden eliminar operaciones completadas hace más de 30 días");
            }
        try 
        {
            var command = new DeleteOperation(id);
            await _operationCommandService.Handler(command);
            return NoContent();

        }
        catch (Exception ex)
        {
            return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }

}
