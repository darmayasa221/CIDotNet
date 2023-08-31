using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.SharedKernel.Interfaces;
using Onboard.Core.Aggregate;
using Swashbuckle.AspNetCore.Annotations;
namespace Onboard.API.Endpoints.User.Update;

public class Update : EndpointBaseAsync
  .WithRequest<UpdateUserRequest>
  .WithActionResult<UpdateUserResponse>
{
  private readonly IRepository<AUser> _repository;

  public Update(IRepository<AUser> repository)
  {
    _repository = repository;
  }

  [HttpPut("/user")]
  [SwaggerOperation(
    Summary = "Updates a new User",
    Description = "Updates a new User",
    OperationId = "User.Update",
    Tags = new[] { "UserEndpoints" })
  ]
  public override async Task<ActionResult<UpdateUserResponse>> HandleAsync(
    UpdateUserRequest r,
    CancellationToken cancellationToken = new())
  {

    var existingProject = await _repository.GetByIdAsync(r.Id, cancellationToken);
    if (existingProject == null)
    {
      return NotFound();
    }
  
    existingProject.UpdateUser(r.Username,r.RoleId);
    await _repository.UpdateAsync(existingProject, cancellationToken);
    var response = new UpdateUserResponse
    (
      id: r.Id,
      message: "success"
    );
    return Ok(response);
  }

}
 