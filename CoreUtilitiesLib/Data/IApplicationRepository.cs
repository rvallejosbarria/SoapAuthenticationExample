using CoreUtilitiesLib.Models;

namespace CoreUtilitiesLib.Data;

public interface IApplicationRepository
{
  User GetUser(string username, string password);
}