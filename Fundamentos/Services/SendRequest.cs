using System.Text;
using System.Text.Json;
using Models;

namespace Fundamentos.Services
{
  public class SendRequest<T> where T : IRequestable
  {
    private readonly HttpClient http = new();
    public async Task<T?> Send(T model)
    {
      const string URL = "https://jsonplaceholder.typicode.com/posts";

      var data = JsonSerializer.Serialize(model);
      var content = new StringContent(data, Encoding.UTF8, "application/json");
      var httpResponse = await http.PostAsync(URL, content);
      if (httpResponse.IsSuccessStatusCode)
      {
        var response = await httpResponse.Content.ReadAsStringAsync();
        var postResult = JsonSerializer.Deserialize<T>(
          response,
          new JsonSerializerOptions()
          {
            PropertyNameCaseInsensitive = true
          }
        );
        return postResult;
      }
      return default(T);
    }
  }
}

