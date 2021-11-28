using System.Text.Json;
using OrderInFrontEndClient.Models;

namespace OrderInFrontEndClient.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly HttpClient _httpClient;
        public RestaurantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<RestaurantList> GetRestaurants(string location, string searchTerm)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7019/");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic");
            var response = _httpClient.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            var responseStream = response.Content.ReadAsStreamAsync().Result;
            return await JsonSerializer.DeserializeAsync<RestaurantList>(responseStream);

        }
    }
}
