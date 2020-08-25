using System;

namespace PartySquirrel.ViewModels
{
  public class CreateSquirrelViewModel
  {
    public string Image { get; set; }
    public string Name { get; set; }
    public string PartyTrick { get; set; }
    public string PartyStory { get; set; }
    public string PartyLocation { get; set; }
    
    public DateTime PartySince { get; set; }
  }
}
