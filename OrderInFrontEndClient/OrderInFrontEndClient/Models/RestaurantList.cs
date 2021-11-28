using System.Net.Http.Json;
using System.Text.Json;

namespace OrderInFrontEndClient.Models
{
    public class RestaurantList
    {
        public IEnumerable<Restaurant> Restaurants {get; set;}  
        public int Count => Restaurants.Count();

        public RestaurantList()
        {
        }

        public RestaurantList(string location, string searchText)
        {
        }

    }
}
