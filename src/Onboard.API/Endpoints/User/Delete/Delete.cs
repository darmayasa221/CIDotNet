using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.User.Delete;

public class Delete : EndpointBaseAsync
.WithRequest<DeleteUserByIdRequest>
.WithActionResult<DeleteUserByIdResponse>
{
  private readonly IRepository<AUser> _repository;

  public Delete(IRepository<AUser> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeleteUserByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Delete a single User",
    Description = "Delete a single User by Id",
    OperationId = "User.DeleteById",
    Tags = new[] { "UserEndpoints" })
  ]
  public override async Task<ActionResult<DeleteUserByIdResponse>> HandleAsync(
    [FromRoute] DeleteUserByIdRequest request,
    CancellationToken cancellationToken = new())
  {

    var user = await _repository.GetByIdAsync(request.id, cancellationToken);

    if (user == null)
    {
      return NotFound();
    }
    await _repository.DeleteAsync(user, cancellationToken);
    var response = new DeleteUserByIdResponse
    (
      id: user.id,
      message: "success"
    );

    return Ok(response);
  }
}
