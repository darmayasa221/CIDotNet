using System;
namespace Onboard.API.Endpoints.Article.GetById
{
  public class GetArticleByIdRequest
  {
    public const string Route = "/Article/{id:Guid}";
    public static string BuildRoute(Guid id) => Route.Replace("{id:Guid}", id.ToString());

    public Guid id { get; set; }
  }
}

