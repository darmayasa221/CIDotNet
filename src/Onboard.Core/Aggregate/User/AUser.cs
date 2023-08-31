using Ardalis.GuardClauses;
using Onboard.SharedKernel;
using Onboard.SharedKernel.Interfaces;


namespace Onboard.Core.Aggregate;

public class AUser : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }
  public string Username { get; private set; }
  public string Email { get; private set; }
  public Guid RoleId { get; private set; }
  public AUser(string name, string username, string email, Guid roleId) 
  {
    Name = name;
    Username = username;
    Email = email;
    RoleId = roleId;
  }
  public void UpdateUser(string name) {
     Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }
}
