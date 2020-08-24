using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PartySquirrelClient.Models
{
  public class Squirrel
  {
    public int SquirrelId { get; set; }

    public Squirrel()
    {
    }

    public static List<Squirrel> GetSquirrels()
    {
      string requestAddress = "Squirrels";
      var apiCallTask = ApiHelper.GetAll(requestAddress);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Squirrel> SquirrelList = JsonConvert.DeserializeObject<List<Squirrel>>(jsonResponse.ToString());

      return SquirrelList;
    }

    public static Squirrel GetDetails(int SquirrelId)
    {
      string requestAddress = $"Squirrels/{SquirrelId}";
      var apiCallTask = ApiHelper.Get(requestAddress);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Squirrel Squirrel = JsonConvert.DeserializeObject<Squirrel>(jsonResponse.ToString());
      return Squirrel;
    }

    public static void Delete(int id)
    {
      string requestAddress = $"Squirrel/{id}";
      var apiCallTask = ApiHelper.Delete(requestAddress);
    }
  }
}