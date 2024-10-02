using Greggs.Products.Services.Models;

namespace Greggs.Products.Services.Contract
{
    public interface IProductsService
    {
        PaginatedList<Product> GetProductsInCurrency(string currency, int? pageStart, int? pageSize);
        PaginatedList<Product> GetProductsSortedByDate(int? pageStart, int? pageSize);
        PaginatedList<Product> GetRandomSelection(int? pageStart, int? pageSize);
    }
}
