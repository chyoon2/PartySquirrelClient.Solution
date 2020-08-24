using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace PartySquirrel.Models
{
  public class Photo
  {
    public string large { get; set; }

    public static string GetPhoto()
    {
      var apiCallTask = ApiHelper.ApiCall(1);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse.ToString());
      
      Random rand = new Random();
      int randomPage = rand.Next(1, apiResponse.total_results);

      var apiCallTask2 = ApiHelper.ApiCall(randomPage);
      var result2 = apiCallTask2.Result;
      JObject jsonResponse2 = JsonConvert.DeserializeObject<JObject>(result2);
      Photo apiResponse2 = JsonConvert.DeserializeObject<Photo>(jsonResponse2["photos"]["src"].ToString());

      return apiResponse2.large;
    }
  }
}