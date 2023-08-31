using System;
using Ardalis.GuardClauses;
using Onboard.SharedKernel;
using Onboard.SharedKernel.Interfaces;

namespace Onboard.Core.Aggregate;

public class ARole : EntityBase, IAggregateRoot
{
  public string roleName { get; set; }
  

  public ARole(string roleName)
  {
    this.roleName = roleName;
  }

  public void UpdateRole(string roleName)
  {
    this.roleName = Guard.Against.NullOrEmpty(roleName, nameof(roleName));
  }
}