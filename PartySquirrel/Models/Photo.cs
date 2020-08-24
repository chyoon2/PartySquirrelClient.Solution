namespace PartySquirrel.Models
{
  public class Photo
  {
    public int id { get; set; } 
    public int width { get; set; } 
    public int height { get; set; } 
    public string url { get; set; } 
    public string photographer { get; set; } 
    public string photographer_url { get; set; } 
    public int photographer_id { get; set; } 
    public Src src { get; set; } 
    public bool liked { get; set; } 
  }
}