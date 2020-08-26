using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PartySquirrel.Models
{
  public class PartyMessage
  {
    public int PartyMessageId { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string UserFromId { get; set; }
    public ApplicationUser UserFrom { get; set; }
    public string MessageBody { get; set; }
  }
}