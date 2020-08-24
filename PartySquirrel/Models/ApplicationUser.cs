using Microsoft.AspNetCore.Identity;

namespace PartySquirrel.Models
{
  enum UserRole {User, Administrator}
  public class ApplicationUser : IdentityUser
  {
    public UserRole Role { get; set; } = UserRole.User;
  }
}