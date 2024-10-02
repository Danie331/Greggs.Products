using Greggs.Products.Persistence;
using Greggs.Products.Persistence.Entities;
using Greggs.Products.Services.Contract;
using Greggs.Products.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Greggs.Products.UnitTests;

public class UserStory1Tests
{
    private ServiceProvider _serviceProvider { get; set; }
    public UserStory1Tests() 
    {
        var serviceCollection = new ServiceCollection();
        // Add Automapper
        serviceCollection.AddAutoMapper(new Assembly[] { Assembly.GetAssembly(typeof(Greggs.Products.Api.Automapper.DomainToDtoMappingProfile)) });
        // DI registration: swop out the dataprovider with a mock data source
        serviceCollection.AddTransient<IDataAccess, MockDataProvider>();
        serviceCollection.AddTransient<IProductsService, ProductService>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public void Test_Returns_Products_Sorted_By_Date_Desc()
    {
        var service = _serviceProvider.GetService<IProductsService>();
        var result = service.GetProductsSortedByDate(null, null);
        var sortedItems = result.Items;

        // Ensure that results are correctly ordered by date
        Assert.True(sortedItems[0].Name.Equals("1"));
        Assert.True(sortedItems[1].Name.Equals("2"));
        Assert.True(sortedItems[2].Name.Equals("3"));
        Assert.True(sortedItems[3].Name.Equals("4"));
    }

    public class MockDataProvider : IDataAccess
    {
        public IEnumerable<Product> List()
        {
            return new Product[] {
            new Product { Name = "1", DateAdded = new DateTime(2024, 10, 2) },
            new Product { Name = "4", DateAdded = new DateTime(2020, 1, 2) },
            new Product { Name = "2", DateAdded = new DateTime(2024, 6, 6) },
            new Product { Name = "3", DateAdded = new DateTime(2022, 9, 5) }
            };
        }
    }
}