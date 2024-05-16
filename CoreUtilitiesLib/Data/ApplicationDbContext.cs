using Microsoft.EntityFrameworkCore;
using CoreUtilitiesLib.Models;

namespace CoreUtilitiesLib.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
}