using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FoodOrderingService.RD;


namespace FoodOrderingService
{
    public class Program
    {

        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<FoodOrderingServer, FoodOrderingServer>();
                    services.AddHostedService<FoodOrdering>();
                }).Build().Run();
        }
    }
}