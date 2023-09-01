using System;
namespace Onboard.API.Endpoints.Article.List
{
  public class ListArticleResponse
  {
    public List<ArticleRecord> Articles { get; set; } = new();
  }
}

