using System.Text;
using CoreUtilitiesLib.Services;

namespace SoapWebService.Middlewares;

public class AuthMiddleware
{
  private readonly RequestDelegate _next;
  private readonly IAuthenticationService _service;

  public AuthMiddleware(RequestDelegate next, IAuthenticationService service)
  {
    _next = next;
    _service = service;
  }

  public async Task InvokeAsync(HttpContext httpContext)
  {
    if (!httpContext.Request.Headers.ContainsKey("Authorization"))
    {
      httpContext.Response.StatusCode = 401;
      await httpContext.Response.WriteAsync("Unauthorized");
      return;
    }

    var header = httpContext.Response.Headers["Authorization"].ToString();
    var encodedCredentials = header.Substring(6);
    var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
    string[] uidpwd = credentials.Split(":");
    var uid = uidpwd[0];
    var password = uidpwd[1];

    if (!_service.Authenticate(uid, password))
    {
      httpContext.Response.StatusCode = 401;
      await httpContext.Response.WriteAsync("Unauthorized");
      return;
    }

    await _next(httpContext);
  }
}