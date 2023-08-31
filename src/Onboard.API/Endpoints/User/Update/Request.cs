namespace Onboard.API.Endpoints.User.Update;

public class UpdateUserRequest
{
  public const string Route = "/user";
  public Guid Id { get;  set; }
  public string Username { get; set; }
  public int RoleId { get; set; }  
}
