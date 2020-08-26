using System;
using PartySquirrel.Models;
using System.Collections.Generic;

namespace PartySquirrel.ViewModels
{
  public class PartyDetailsViewModel
  {
    public ApplicationUser User { get; set; }
    public ApplicationUser CurrentUser { get; set; }
    public int SquirrelCount { get; set; }
    public List<SquirrelUser> Column1 { get; set; }
    public List<SquirrelUser> Column2 { get; set; }
    public List<SquirrelUser> Column3 { get; set; }
    public List<PartyMessage> PartyMessages { get; set; }

    public PartyDetailsViewModel()
    {
      this.Column1 = new List<SquirrelUser>();
      this.Column2 = new List<SquirrelUser>();
      this.Column3 = new List<SquirrelUser>();
    }
  }
}
