using System.ComponentModel.DataAnnotations;

namespace CoreUtilitiesLib.Models;

public class User
{
  [Key]
  public string Username { get; set; }
  public string Password { get; set; }
}