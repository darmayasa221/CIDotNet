using System;
using Ardalis.GuardClauses;
using Onboard.SharedKernel;
using Onboard.SharedKernel.Interfaces;

namespace Onboard.Core.Aggregate;

public class AArticle : EntityBase, IAggregateRoot
{
  public string title { get; set; }
  public string content { get;  set; }
  public string link { get; set; }
  public Guid userId { get; set; }
 
  public AArticle(string title, string content, string link, Guid userId)
  {
    this.title = title;
    this.content = content;
    this.link = link;
    this.userId = userId;
  }

  public void UpdateArticle(string title)
  {
    this.title = Guard.Against.NullOrEmpty(title, nameof(title));
  }
 }

