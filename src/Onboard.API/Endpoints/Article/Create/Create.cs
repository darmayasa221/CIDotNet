using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.API.Endpoints.User.Create;
using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.Article.Create
{
  public class Create : EndpointBaseAsync
  .WithRequest<CreateArticleRequest>
  .WithActionResult<CreateArticleResponse>
  {
    private readonly IRepository<AArticle> _repository;

    public Create(IRepository<AArticle> repository)
    {
      _repository = repository;
    }

    [HttpPost("/article")]
    [SwaggerOperation(
      Summary = "Creates a new article",
      Description = "Creates a new article",
      OperationId = "Article.Create",
      Tags = new[] { "ArticleEndpoints" })
    ]
    public override async Task<ActionResult<CreateArticleResponse>> HandleAsync(
      CreateArticleRequest r,
      CancellationToken cancellationToken = new())
    {

      var newArticle = new AArticle(r.Title, r.Content, r.Link, r.UserId);
      var createdArticle = await _repository.AddAsync(newArticle, cancellationToken);
      var response = new CreateArticleResponse(id: createdArticle.id);

      return Ok(response);
    }
  }
}
