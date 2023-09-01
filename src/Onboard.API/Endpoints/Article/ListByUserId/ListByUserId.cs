using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.Core.Aggregate;
using Onboard.Core.Aggregate.Article.Specifications;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.Article.ListByUserId
{
  public class ListByUserId : EndpointBaseAsync
  .WithRequest<ListArticleByUserIdRequest>
  .WithActionResult<ListArticleByUserIdResponse>
  {
    private readonly IRepository<AUser> _repository;

    public ListByUserId(IRepository<AUser> repository)
    {
      _repository = repository;
    }

    [HttpGet(ListArticleByUserIdRequest.Route)]
    [SwaggerOperation(
      Summary = "Gets list of article by user",
      Description = "Gets list of article by user id",
      OperationId = "Articles.ListArticleByUserIdRequest",
      Tags = new[] { "ArticleEndpoints" })
      ]
    public override async Task<ActionResult<ListArticleByUserIdResponse>> HandleAsync(
      [FromRoute] ListArticleByUserIdRequest request,
      CancellationToken cancellationToken = new())
    {
      var spec = new UserByIdWithArticles(request.id);
      var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
      if (entity == null)
      {
        return NotFound();
      }

      var response = new ListArticleByUserIdResponse
      (
        userId: entity.id,
        articles: entity.Articles.Select(article => new ArticleRecord(article.id, article.title, article.content, article.link))
          .ToList()
      );

      return Ok(response);
    }
  }
}