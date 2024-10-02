using Greggs.Products.Persistence.Entities;

namespace Greggs.Products.Persistence;

public interface IDataAccess
{
    IEnumerable<Product> List();
}