namespace Onboard.API.Endpoints.User.GetById;

public class GetUserByIdResponse
{
  public GetUserByIdResponse(
    Guid id)
  {
    Id = id;
  }

  public Guid Id { get; set; }
}

