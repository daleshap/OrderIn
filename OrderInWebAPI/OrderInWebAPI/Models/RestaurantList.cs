using System.Net.Http.Json;
using System.Text.Json;

namespace OrderInWebAPI.Models
{
    public class RestaurantList
    {
        public IEnumerable<Restaurant> Restaurants { get; set;}
        public int Count => Restaurants.Count();

        public RestaurantList()
        {
            string fileName = "~\\..\\Sample Data\\SampleData.json";
            string jsonString = File.ReadAllText(fileName);
            Restaurants = JsonSerializer.Deserialize<IEnumerable<Restaurant>>(jsonString);
        }
    }
}
