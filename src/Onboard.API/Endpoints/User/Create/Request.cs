namespace Onboard.API.Endpoints.User.Create;

public class CreateUserRequest
{
  public const string Route = "/user";

  public string Name { get;  set; }

  public string Username { get;  set; }

  public string Email { get;  set; }

  public int RoleId { get;  set; }
}
