using System;
namespace Onboard.API.Endpoints.Article.GetById
{
  public class GetArticleByIdResponse
  {
    public GetArticleByIdResponse(
      Guid id,
      string title,
      string content,
      string link,
      DateTime? createdAt,
      DateTime? updatedAt,
      Guid userId)
    {
      Id = id;
      Title = title;
      Content = content;
      Link = link;
      CreatedAt = createdAt;
      UpdatedAt = updatedAt;
      UserId = userId;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Link { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid UserId { get; set; }
  }
}

