using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.User.GetUsers;

public class GetUsers : EndpointBaseAsync
.WithoutRequest
.WithActionResult<ListUsersResponse>
{
  private readonly IRepository<AUser> _repository;

  public GetUsers(IRepository<AUser> repository)
  {
    _repository = repository;
  }

  [HttpGet("/user")]
  [SwaggerOperation(
    Summary = "Get Users",
    Description = "Get Users ",
    OperationId = "User.GetUsers",
    Tags = new[] { "UserEndpoints" })
  ]
  public override async Task<ActionResult<ListUsersResponse>> HandleAsync(
    CancellationToken cancellationToken = new())
  {

    var users = await _repository.ListAsync(cancellationToken);
        var response = new ListUsersResponse
    {
      Users = users
        .Select(user => new UserRecord(user.id,user.Name ,user.Username, user.Email,user.RoleId))
        .ToList()
    };
   
    return Ok(response);
  }
}
