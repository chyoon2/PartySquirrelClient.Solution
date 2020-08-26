using System.Collections.Generic;

namespace PartySquirrel.Models
{
  public class Root
  {
    public int total_results { get; set; } = 0;
    public int page { get; set; } 
    public int per_page { get; set; } 
    public List<Photo> photos { get; set; } 
    public string next_page { get; set; } 
  }
}