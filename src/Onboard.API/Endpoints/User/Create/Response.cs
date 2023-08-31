namespace Onboard.API.Endpoints.User.Create;
public class CreateUserResponse
{  
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; } 
  public CreateUserResponse(Guid id, string name, string email)
  {
    Id = id;
    Name = name;
    Email = email;
  }
}
