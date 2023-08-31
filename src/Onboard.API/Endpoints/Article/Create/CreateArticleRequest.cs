using System;
namespace Onboard.API.Endpoints.Article.Create
{
  public class CreateArticleRequest
  {
    public const string Route = "/article";

    public string Title { get; set; }

    public string Content { get; set; }

    public string Link { get; set; }

    public Guid UserId { get; set; }
  }
}



