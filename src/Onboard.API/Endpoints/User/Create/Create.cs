using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.SharedKernel.Interfaces;
using Onboard.Core.Aggregate;
using Swashbuckle.AspNetCore.Annotations;
namespace Onboard.API.Endpoints.User.Create;

public class Create : EndpointBaseAsync
  .WithRequest<CreateUserRequest>
  .WithActionResult<CreateUserResponse>
{
  private readonly IRepository<AUser> _repository;

  public Create(IRepository<AUser> repository)
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
  public override async Task<ActionResult<CreateUserResponse>> HandleAsync(
    CreateUserRequest r,
    CancellationToken cancellationToken = new())
  {

    var newUser = new AUser(r.Name, r.Username, r.Email, r.RoleId);
    var createdUser = await _repository.AddAsync(newUser, cancellationToken);
    var response = new CreateUserResponse(id: createdUser.id);
    
    return Ok(response);
  }
}
