using System.Net;

namespace Dojo.API;

public class WarrantyApiService
{
    public Task<HttpResponseMessage> GetWarrantyDurationForProducts(IReadOnlyList<int> productIds)
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
                Content = new StringContent(@"[{""productId"": 1, ""duration"": ""2 Years""}, {""productId"": 2, ""duration"": ""5 Years""}]")
            });
    }
}