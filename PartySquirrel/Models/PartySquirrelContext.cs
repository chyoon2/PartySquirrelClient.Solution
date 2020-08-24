using Microsoft.EntityFrameworkCore;
using System;

namespace PartySquirrel.Models
{
  public class  PartySquirrelContext : DbContext
  {
    public PartySquirrelContext(DbContextOptions<PartySquirrelContext> options)
        : base(options)
    {
    }
    public DbSet<Squirrel> Squirrels { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {}

  }
}