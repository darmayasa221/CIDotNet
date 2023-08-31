namespace Onboard.API.Endpoints.User.GetById;

public class GetUserByIdRequest
{
  public const string Route = "/user/{id:Guid}";
  public static string BuildRoute(Guid id) => Route.Replace("{id:Guid}", id.ToString());

  public Guid id { get; set; }
}

