using System.Net;

namespace Dojo.API;

public class ProductApiService
{
    public Task<HttpResponseMessage> GetProducts()
    {
        /*var random = new Random();
        if (random.Next() % 2 == 0)
        {
            return Task.FromResult(
                new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode) 500,
                    Content = new StringContent("[]")
                });
        }*/
        
        return Task.FromResult(
            new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode) 200,
                Content = new StringContent(@"[{""Id"": 1, ""Name"": ""Notebook""}, {""Id"": 2, ""Name"": ""Sofa""}]")
            });
    }
}