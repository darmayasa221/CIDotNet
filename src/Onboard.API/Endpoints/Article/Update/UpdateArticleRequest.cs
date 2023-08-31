using System;
using System.ComponentModel.DataAnnotations;

namespace Onboard.API.Endpoints.Article.Update
{
  public class UpdateArticleRequest
  {
    public const string Route = "/article";

    [Required]
    public Guid id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string Link { get; set; }

    public Guid UserId { get; set; }
  }
}
