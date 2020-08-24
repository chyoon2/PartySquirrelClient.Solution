namespace PartySquirrel.Models
{
  public class SquirrelUser
  {
    public int SquirrelUserId { get; set; }
    public int SquirrelId { get; set; }
    public int UserId { get; set; }
    public Squirrel Squirrel { get; set; }
    public ApplicationUser User { get; set; }
  }
}