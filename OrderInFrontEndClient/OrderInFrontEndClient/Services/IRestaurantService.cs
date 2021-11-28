using OrderInFrontEndClient.Models;

namespace OrderInFrontEndClient.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantList> GetRestaurants(string location, string searchTerm);
    }
}
