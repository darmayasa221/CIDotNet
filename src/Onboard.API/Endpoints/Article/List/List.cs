using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.Article.List
{
  public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<ListArticleResponse>
  {
    private readonly IReadRepository<AArticle> _repository;

    public List(IReadRepository<AArticle> repository)
    {
      _repository = repository;
    }

    [HttpGet("/article")]
    [SwaggerOperation(
        Summary = "Gets a list of all article",
        Description = "Gets a list of all article",
        OperationId = "Article.List",
        Tags = new[] { "ArticleEndpoints" })
    ]
    public override async Task<ActionResult<ListArticleResponse>> HandleAsync(
      CancellationToken cancellationToken = new())
    {
      var articles = await _repository.ListAsync(cancellationToken);
      var response = new ListArticleResponse
      {
        Articles = articles
          .Select(article => new ArticleRecord(article.id, article.title, article.content, article.link))
          .ToList()
      };

      return Ok(response);
    }
  }
}
