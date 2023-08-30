using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.SharedKernel.Interfaces;
using Onboard.Core.Aggregate.User;
using Swashbuckle.AspNetCore.Annotations;
namespace Onboard.API.Endpoints.User;

public class Create : EndpointBaseAsync
  .WithRequest<Request>
  .WithActionResult<Response>
{
  private readonly IRepository<UserAggregate> _repository;

  public Create(IRepository<UserAggregate> repository)
  {
    _repository = repository;
  }

  [HttpPost("/user")]
  [SwaggerOperation(
    Summary = "Creates a new User",
    Description = "Creates a new User",
    OperationId = "User.Create",
    Tags = new[] { "UserEndpoints" })
  ]
  public override async Task<ActionResult<Response>> HandleAsync(
    Request request,
    CancellationToken cancellationToken = new())
  {
    if (request.Name == null)
    {
      return BadRequest();
    }

    var newProject =  new UserAggregate(request.Name);
    var createdItem = await _repository.AddAsync(newProject, cancellationToken);
    var response = new Response
    (
      id: createdItem.Id,
      name: createdItem.Name
    );

    return Ok(response);
  }
}

