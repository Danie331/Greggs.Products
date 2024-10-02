using Greggs.Products.Services.Contract;
using Greggs.Products.Services.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Greggs.Products.Api
{
    public static class DependencyRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IProductsService, ProductService>();
            Persistence.DependencyRegistration.Register(services);
        }
    }
}
