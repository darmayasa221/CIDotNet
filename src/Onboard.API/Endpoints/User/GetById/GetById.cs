using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.User.GetById;

public class GetById : EndpointBaseAsync
.WithRequest<GetUserByIdRequest>
.WithActionResult<GetUserByIdResponse>
{
  private readonly IRepository<AUser> _repository;

  public GetById(IRepository<AUser> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetUserByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Get a single User",
    Description = "Get a single User by Id",
    OperationId = "User.GetById",
    Tags = new[] { "UserEndpoints" })
  ]
  public override async Task<ActionResult<GetUserByIdResponse>> HandleAsync(
    [FromRoute] GetUserByIdRequest request,
    CancellationToken cancellationToken = new())
  {

    var user = await _repository.GetByIdAsync(request.id, cancellationToken);
    
    if (user == null)
    {
      return NotFound();
    }

    var response = new GetUserByIdResponse
    (
      id: user.id
    );

    return Ok(response);
  }
}
