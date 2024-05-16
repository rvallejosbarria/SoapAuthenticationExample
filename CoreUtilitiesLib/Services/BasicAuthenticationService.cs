namespace CoreUtilitiesLib.Services;

public class BasicAuthenticationService : IAuthenticationService
{
  public bool Authenticate(string username, string password)
  {
    return true;
  }
}