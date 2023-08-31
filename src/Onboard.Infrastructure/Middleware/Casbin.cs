using Onboard.Core.Aggregate;
using Onboard.SharedKernel.Interfaces;
using Casbin;
using Microsoft.AspNetCore.Http;

namespace Onboard.Infrastructure.Middleware;

public class MiddlewareCasbin
{
  private readonly IRepository<AUser> _repository;
  private readonly CancellationToken _cancellationToken;
  private readonly RequestDelegate _next;
  private string path { get; set; }
  private string method { get; set; }

  public MiddlewareCasbin(RequestDelegate next, IRepository<AUser> repository, CancellationToken cancellationToken = new())
  {
    _repository = repository;
    _cancellationToken = cancellationToken;
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    path = context.Request.Path.ToString();
    method = context.Request.Method.ToString();
    if (context.Request.Headers.TryGetValue("userId", out var userIdHeader))
    {
      var userId = Guid.Parse(userIdHeader);
      var existingProject = await _repository.GetByIdAsync(userId, _cancellationToken);
      if (existingProject == null)
      {
        await context.Response.WriteAsync("user not found");
        return;
      }

      var e = new Enforcer("model.conf", "policy.csv");

      var flag = await e.EnforceAsync("user", path, method);
      if (!flag)
      {
        await context.Response.WriteAsync("not user");
        return;
      }
      await _next.Invoke(context);
    }
  }
}
