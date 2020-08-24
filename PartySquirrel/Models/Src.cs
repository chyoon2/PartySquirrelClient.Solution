using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PartySquirrel.Models
{
  public class Src
  {
    public string large { get; set; }

    public static string GetPhoto()
    {
      var apiCallTask = ApiHelper.ApiCall(1);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Root root = JsonConvert.DeserializeObject<Root>(jsonResponse.ToString());
      
      Random rand = new Random();
      int randomPage = rand.Next(1, root.total_results);

      var apiCallTask2 = ApiHelper.ApiCall(randomPage);
      var result2 = apiCallTask2.Result;
      JObject jsonResponse2 = JsonConvert.DeserializeObject<JObject>(result2);
      Src apiResponse2 = JsonConvert.DeserializeObject<Src>(jsonResponse2["photos"]["src"].ToString());

      return apiResponse2.large;
    }
  }
}