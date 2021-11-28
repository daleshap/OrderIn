using Microsoft.AspNetCore.Builder;
using OrderInFrontEndClient.Services;

namespace OrderInFrontEndClient
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IRestaurantService, RestaurantService>(c => c.BaseAddress = new Uri("https://localhost:7019/"));
        }
    }
}
