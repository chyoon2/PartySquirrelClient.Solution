using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace PartySquirrel.Models
{
  public class  PartySquirrelContext : IdentityDbContext<ApplicationUser>
  {
    public PartySquirrelContext(DbContextOptions<PartySquirrelContext> options)
        : base(options)
    {
    }
    public DbSet<Squirrel> Squirrels { get; set; }
    public DbSet<SquirrelUser> SquirrelUser { get; set; }
    public DbSet<PartyMessage> PartyMessages { get; set; }

  }
}