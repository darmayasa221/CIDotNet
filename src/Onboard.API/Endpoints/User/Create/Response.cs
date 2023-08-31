namespace Onboard.API.Endpoints.User.Create;
public class CreateUserResponse
{  
  public Guid Id { get; set; }
  
  public CreateUserResponse(Guid id)
  {
    Id = id;
  }
}
