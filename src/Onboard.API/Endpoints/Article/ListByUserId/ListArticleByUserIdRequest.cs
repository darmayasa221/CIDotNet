using System;
namespace Onboard.API.Endpoints.Article.ListByUserId
{
  public class ListArticleByUserIdRequest
  {

    public const string Route = "/userArticle/{id:Guid}";
    public static string BuildRoute(Guid id) => Route.Replace("{id:Guid}", id.ToString());

    public Guid id { get; set; }
  }
}

