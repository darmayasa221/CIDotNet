using System;
namespace Onboard.API.Endpoints.Article.Create
{
  public class CreateArticleResponse
  {
    public Guid Id { get; set; }

    public CreateArticleResponse(Guid id)
    {
      Id = id;
    }
  }
}

