using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PartySquirrel.Models
{
  public class Src
  {
    public string original { get; set; } 
    public string large2x { get; set; } 
    public string large { get; set; } 
    public string medium { get; set; } 
    public string small { get; set; } 
    public string portrait { get; set; } 
    public string landscape { get; set; } 
    public string tiny { get; set; } 

    public static string GetPhoto()
    {
      var apiCallTask = ApiHelper.ApiCall(1);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Root root = JsonConvert.DeserializeObject<Root>(jsonResponse.ToString());
      if (root.total_results == 0)
      {
        return "/img/default_squirrel.jpg";
      }
      else
      {
        Random rand = new Random();
        int randomPage = rand.Next(1, root.total_results);
        var apiCallTask2 = ApiHelper.ApiCall(randomPage);
        var result2 = apiCallTask2.Result;
        JObject jsonResponse2 = JsonConvert.DeserializeObject<JObject>(result2);
        Root apiResponse2 = JsonConvert.DeserializeObject<Root>(jsonResponse2.ToString());
        return apiResponse2.photos[0].src.large;
      }
      
    }
  }
}