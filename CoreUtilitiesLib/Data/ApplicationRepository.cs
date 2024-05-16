using CoreUtilitiesLib.Models;

namespace CoreUtilitiesLib.Data;

public class ApplicationRepository : IApplicationRepository
{
  private readonly ApplicationDbContext _context;

  public ApplicationRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public User GetUser(string username, string password)
  {
    return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
  }
}