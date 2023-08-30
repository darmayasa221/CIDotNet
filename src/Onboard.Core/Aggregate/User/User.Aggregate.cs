using Ardalis.GuardClauses;
using Onboard.SharedKernel.User;
using Onboard.SharedKernel.Interfaces;

namespace Onboard.Core.Aggregate.User;

public class UserAggregate : UserEntity, IAggregateRoot
{
  public string Name { get; private set; }

  public UserAggregate(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }
}
