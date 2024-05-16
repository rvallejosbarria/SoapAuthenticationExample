namespace CoreUtilitiesLib.Services;

public class JwtAuthenticationService : IAuthenticationService
{
  public bool Authenticate(string username, string password)
  {
    return true;
  }
}