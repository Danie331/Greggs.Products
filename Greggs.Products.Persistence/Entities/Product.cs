
namespace Greggs.Products.Persistence.Entities
{
    /// <summary>
    /// ORM entity
    /// </summary>
    public class Product
    {
        public string Name { get; set; }
        public decimal PriceInPounds { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
