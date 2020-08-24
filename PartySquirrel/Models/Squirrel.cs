using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PartySquirrel.Models
{
  public class Squirrel
  {
    public Squirrel()
    {
      this.Users = new HashSet<SquirrelUser>();
    }
    public int SquirrelId { get; set; }
    public string Image { get; set; }
    public string Creator { get; set; }
    public ICollection<SquirrelUser> Users { get; set; }
    public string Name { get; set; }
    public string PartyTrick { get; set; }
    public string PartyStory { get; set; }
    public string PartyLocation { get; set; }
    public DateTime PartySince { get; set; } = DateTime.Now;
    
  }
}