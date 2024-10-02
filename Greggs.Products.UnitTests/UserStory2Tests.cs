using Greggs.Products.Persistence;
using Greggs.Products.Services.Contract;
using Greggs.Products.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace Greggs.Products.UnitTests
{
    public class UserStory2Tests
    {
        private ServiceProvider _serviceProvider { get; set; }
        public UserStory2Tests()
        {
            var serviceCollection = new ServiceCollection();
            // Add Automapper
            serviceCollection.AddAutoMapper(new Assembly[] { Assembly.GetAssembly(typeof(Greggs.Products.Api.Automapper.DomainToDtoMappingProfile)) });
            // DI registration: swop out the dataprovider with a mock data source
            serviceCollection.AddTransient<IDataAccess, ProductAccess>();
            serviceCollection.AddTransient<IProductsService, ProductService>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public void Test_Exchange_Rate_Produces_Correct_Output()
        {
            var service = _serviceProvider.GetService<IProductsService>();
            var result = service.GetProductsInCurrency("EUR", null, null);            
            var items = result.Items;

            var currencyLookup = new Dictionary<string, decimal>() { { "EUR", 1.11m } };

            // Assert the correct exchange rate is calculated
            var inPounds = items[0].PriceInPounds;
            var inEuros = items[0].PriceInEuros;

            Assert.Equal(inPounds * currencyLookup.Values.First(), inEuros);
        }
    }
}
