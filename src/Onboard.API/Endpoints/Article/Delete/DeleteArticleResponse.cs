using System;
namespace Onboard.API.Endpoints.Article.Delete
{
  public class DeleteArticleResponse
  {
    public Guid Id { get; set; }
    public string Message { get; set; }

    public DeleteArticleResponse(Guid id, string message)
    {
      Id = id;
      Message = message;
    }
  }
}

