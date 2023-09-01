using System;
using System.Xml.Linq;

namespace Onboard.API.Endpoints.Article.ListByUserId
{
  public class ListArticleByUserIdResponse
  {
    public ListArticleByUserIdResponse(Guid userId, List<ArticleRecord> articles)
    {
      this.userId = userId;
      Articles = articles;
    }

    public Guid userId { get; set; }
    public List<ArticleRecord> Articles { get; set; } = new();
  }
}

