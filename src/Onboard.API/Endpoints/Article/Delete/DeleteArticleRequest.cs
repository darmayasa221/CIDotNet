using System;
namespace Onboard.API.Endpoints.Article.Delete
{
  public class DeleteArticleRequest
  {
    public const string Route = "/article/{id:Guid}";
    public static string BuildRoute(Guid id) => Route.Replace("{id:Guid}", id.ToString());

    public Guid id { get; set; }
  }
}

