using Microsoft.AspNetCore.Mvc;
using OrderInWebAPI.Models;

namespace OrderInWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController(ILogger<RestaurantController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRestaurantList")]
        public RestaurantList Get()
        {
            return new RestaurantList();    
        }
    }
}
