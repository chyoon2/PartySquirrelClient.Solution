using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PartySquirrel.Models
{
  public class PartySquirrelContextFactory : IDesignTimeDbContextFactory<PartySquirrelContext>
  {
    PartySquirrelContext IDesignTimeDbContextFactory<PartySquirrelContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<PartySquirrelContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new PartySquirrelContext(builder.Options);
    }
  }
}