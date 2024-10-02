using Microsoft.Extensions.DependencyInjection;

namespace Greggs.Products.Persistence
{
    public static class DependencyRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IDataAccess, ProductAccess>();
        }
    }
}
