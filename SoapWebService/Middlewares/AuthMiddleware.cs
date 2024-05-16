using System.Text;
using CoreUtilitiesLib.Services;

namespace SoapWebService.Middlewares;

public class AuthMiddleware
{
  private readonly RequestDelegate _next;

  public AuthMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext httpContext, IAuthenticationService service)
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

    if (!service.Authenticate(uid, password))
    {
      httpContext.Response.StatusCode = 401;
      await httpContext.Response.WriteAsync("Unauthorized");
      return;
    }

    await _next(httpContext);
  }
}