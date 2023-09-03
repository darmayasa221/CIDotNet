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

  private string role { get; set; }

  public MiddlewareCasbin(RequestDelegate next, IRepository<AUser> repository, CancellationToken cancellationToken = new())
  {
    _repository = repository;
    _cancellationToken = cancellationToken;
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    path = context.Request.Path.ToString();
    if(path == "/swagger/index.html")
    {
      await _next.Invoke(context);
      return;
    }
    method = context.Request.Method.ToString();
    if (context.Request.Headers.TryGetValue("userId", out var userIdHeader))
    {
      var userId = Guid.Parse(userIdHeader);
      var user = await _repository.GetByIdAsync(userId, _cancellationToken);
      if (user == null)
      {
        await context.Response.WriteAsync("user not found");
        return;
      }

      var e = new Enforcer("model.conf", "policy.csv");

      role = user.RoleId == 1 ? "admin" : "employee";

      var flag = await e.EnforceAsync(role, path, method);
      if (!flag)
      {
        await context.Response.WriteAsync("not admin");
        return;
      }
      await _next.Invoke(context);
      return;
    }
    await context.Response.WriteAsync("unauthorized");
    return;
  }
}
