using PartySquirrel.Models;

namespace PartySquirrel.ViewModels
{
  public class CreatePartyMessageViewModel
  {
    public string UserId { get; set; }
    public string UserFromId { get; set; }
    public string MessageBody { get; set; }
  }
}