namespace Onboard.API.Endpoints.User.Update;
public class UpdateUserResponse
{
  public Guid Id { get; set; }
  public string Message { get; set; }
  public UpdateUserResponse(Guid id, string message)
  {
    Id = id;
    Message = message;
  }
 
}
