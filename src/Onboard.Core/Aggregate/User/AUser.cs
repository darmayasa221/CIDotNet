using Onboard.SharedKernel;
using Onboard.SharedKernel.Interfaces;


namespace Onboard.Core.Aggregate;

public class AUser : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }
  public string Username { get; private set; }
  public string Email { get; private set; }
  public int RoleId { get; private set; }


  private List<AArticle> _articles = new List<AArticle>();
  public IEnumerable<AArticle> Articles => _articles.AsReadOnly();

  public AUser(string name, string username, string email, int roleId) 
  {
    Name = name;
    Username = username;
    Email = email;
    RoleId = roleId;
  }
  public void UpdateUser(string username, int roleId) {
     Username = username;
     RoleId = roleId;
  }
}
