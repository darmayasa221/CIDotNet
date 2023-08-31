using System;
namespace Onboard.API.Endpoints.Article.Update
{
  public class UpdateArticleResponse
  {
    public Guid id { get; set; }

    public UpdateArticleResponse(Guid id)
    {
      this.id = id;
    }

    public UpdateArticleResponse(ArticleRecord article)
    {
      Article = article;
    }
    public ArticleRecord Article { get; set; }
  }
}

