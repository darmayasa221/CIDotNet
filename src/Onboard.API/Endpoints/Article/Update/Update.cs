using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.API.Endpoints.User.Create;
using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.Article.Update
{
  public class Update : EndpointBaseAsync
    .WithRequest<UpdateArticleRequest>
    .WithActionResult<UpdateArticleResponse>
  {
    private readonly IRepository<AArticle> _repository;

    public Update(IRepository<AArticle> repository)
    {
      _repository = repository;
    }

    [HttpPut(UpdateArticleRequest.Route)]
    [SwaggerOperation(
     Summary = "Updates an article",
     Description = "Updates an article",
     OperationId = "Article.Update",
     Tags = new[] { "ArticleEndpoints" })
 ]
    public override async Task<ActionResult<UpdateArticleResponse>> HandleAsync(UpdateArticleRequest request,
     CancellationToken cancellationToken = new())
    {
      if (request.Title == null)
      {
        return BadRequest();
      }

      var existingArticle = await _repository.GetByIdAsync(request.id, cancellationToken);
      if (existingArticle == null)
      {
        return NotFound();
      }

      existingArticle.UpdateArticle(request.Title);

      await _repository.UpdateAsync(existingArticle, cancellationToken);

      var response = new UpdateArticleResponse(
          article: new ArticleRecord(existingArticle.id, existingArticle.title)
      );

      return Ok(response);
    }

  }
}