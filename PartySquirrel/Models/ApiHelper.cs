using System.Threading.Tasks;
using RestSharp;

namespace PartySquirrel.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCall(int page)
    {
      RestClient client = new RestClient("https://api.pexels.com/v1/search");
      RestRequest request = new RestRequest($"?query=squirrel?&per_page=1&page={page}", Method.GET);
      request.AddHeader("Authorization", "563492ad6f91700001000001d48350852cf54c34b23724a5f56ff28f");
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }    
  }
}