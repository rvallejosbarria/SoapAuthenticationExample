using CoreUtilitiesLib.Data;

namespace CoreUtilitiesLib.Services;

public class BasicAuthenticationService : IAuthenticationService
{
  private readonly IApplicationRepository _repository;

  public BasicAuthenticationService(IApplicationRepository repository)
  {
    _repository = repository;
  }

  public bool Authenticate(string username, string password)
  {
    var user = _repository.GetUser(username, password);

    if (user != null) {
      return true;
    }

    return false;
  }
}