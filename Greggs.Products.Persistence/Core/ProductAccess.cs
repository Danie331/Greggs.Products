
using Greggs.Products.Persistence.Entities;

namespace Greggs.Products.Persistence;

public class ProductAccess : IDataAccess
{
    private static readonly IEnumerable<Product> ProductDatabase = new List<Product>()
    {
        new() { Name = "Sausage Roll", PriceInPounds = 1m, DateAdded = new DateTime(2023, 1, 3) },
        new() { Name = "Vegan Sausage Roll", PriceInPounds = 1.1m, DateAdded = new DateTime(2022, 10, 29) },
        new() { Name = "Steak Bake", PriceInPounds = 1.2m, DateAdded = new DateTime(2020, 5, 16) },
        new() { Name = "Yum Yum", PriceInPounds = 0.7m, DateAdded = new DateTime(2024, 9, 9) },
        new() { Name = "Pink Jammie", PriceInPounds = 0.5m, DateAdded = new DateTime(2021, 4, 19) },
        new() { Name = "Mexican Baguette", PriceInPounds = 2.1m, DateAdded = new DateTime(2022, 7, 8) },
        new() { Name = "Bacon Sandwich", PriceInPounds = 1.95m, DateAdded = new DateTime(2020, 8, 15) },
        new() { Name = "Coca Cola", PriceInPounds = 1.2m, DateAdded = new DateTime(2024, 1, 27) }
    };

    /// <summary>
    /// Returns a flat list for this implementation
    /// </summary>
    public IEnumerable<Product> List() => ProductDatabase;
}