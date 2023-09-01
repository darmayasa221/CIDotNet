using System;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Onboard.API.Endpoints.Article.Update;
using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Onboard.API.Endpoints.Article.Delete
{
  public class Delete : EndpointBaseAsync
    .WithRequest<DeleteArticleRequest>
    .WithoutResult
  {
      
  private readonly IRepository<AArticle> _repository;

    public Delete(IRepository<AArticle> repository)
    {
      _repository = repository;
    }

    [HttpDelete(DeleteArticleRequest.Route)]
    [SwaggerOperation(
        Summary = "Deletes an article",
        Description = "Deletes an article",
        OperationId = "Article.Delete",
        Tags = new[] { "ArticleEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(
      [FromRoute] DeleteArticleRequest request,
        CancellationToken cancellationToken = new())
    {
      var article = await _repository.GetByIdAsync(request.id, cancellationToken);
      if (article == null)
      {
        return NotFound();
      }

      await _repository.DeleteAsync(article, cancellationToken);

      var response = new UpdateArticleResponse(
        id: request.id,
        message: "success"
      );

      return Ok(response);
    }
  }

}
