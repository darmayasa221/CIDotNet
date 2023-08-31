using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.Article.GetById
{
  public class GetById : EndpointBaseAsync
  .WithRequest<GetArticleByIdRequest>
  .WithActionResult<GetArticleByIdResponse>
  {
    private readonly IRepository<AArticle> _repository;

    public GetById(IRepository<AArticle> repository)
    {
      _repository = repository;
    }

    [HttpGet(GetArticleByIdRequest.Route)]
    [SwaggerOperation(
      Summary = "Gets a single article",
      Description = "Gets a single article by Id",
      OperationId = "Articles.GetById",
      Tags = new[] { "ArticleEndpoints" })
    ]
    public override async Task<ActionResult<GetArticleByIdResponse>> HandleAsync(
      [FromRoute] GetArticleByIdRequest request,
      CancellationToken cancellationToken = new())
    {
      //var spec = new ProjectByIdWithItemsSpec(request.id);

      var article = await _repository.GetByIdAsync(request.id, cancellationToken);
      //var article = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
      if (article == null)
      {
        return NotFound();
      }

      var response = new GetArticleByIdResponse
      (
        id: article.id,
        title: article.title,
        content: article.content,
        link: article.link,
        userId: article.userId,
        createdAt: article.createdAt,
        updatedAt: article.updatedAt
      );

      return Ok(response);
    }
  }
}