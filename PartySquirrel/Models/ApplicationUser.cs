using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PartySquirrel.Models
{
  public enum UserRole {User, Administrator}
  public class ApplicationUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
  }
}