using Microsoft.AspNetCore.Mvc;
using OrderInFrontEndClient.Services;
using System.Diagnostics;

namespace OrderInFrontEndClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantService _restaurantService;  
        public HomeController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService; 
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var resuarantList = await _restaurantService.GetRestaurants("Cape Town", "Tacos");
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
            return View();
        }
    }
}
