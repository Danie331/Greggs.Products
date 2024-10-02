using Greggs.Products.Services.Models;

namespace Greggs.Products.Services.Contract
{
    public interface IProductsService
    {
        PaginatedList<Product> GetRandomSelection(int? pageStart, int? pageSize);
    }
}
