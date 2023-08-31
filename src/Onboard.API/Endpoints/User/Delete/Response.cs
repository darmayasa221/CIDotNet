namespace Onboard.API.Endpoints.User.Delete;

public class DeleteUserByIdResponse
{
  public Guid Id { get; set; }
  public string Message { get; set; }
  public DeleteUserByIdResponse(Guid id, string message)
  {
    Id = id;
    Message = message;
  }
}

