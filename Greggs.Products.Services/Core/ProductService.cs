using AutoMapper;
using Greggs.Products.Persistence;
using Greggs.Products.Services.Contract;
using Greggs.Products.Services.Models;

namespace Greggs.Products.Services.Core
{
    public class ProductService : IProductsService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IMapper _mapper;
        public ProductService(IDataAccess dataAccess, IMapper mapper)
        {
            _dataAccess = dataAccess;
            _mapper = mapper;
        }

        public PaginatedList<Product> GetRandomSelection(int? pageStart, int? pageSize)
        {
            var selection = GetRandomList();
            var count = selection.Count;
            if (pageStart.HasValue && pageSize.HasValue)
            {
                var pagedData = selection.Skip((pageStart.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
                var totalPages = (int)Math.Ceiling(count / (double)pageSize.Value);

                return new PaginatedList<Product>(pagedData, pageStart.Value, pageSize.Value, totalPages, count);
            }

            return new PaginatedList<Product>(selection, 1, count, 1, count);
        }

        private List<Product> GetRandomList()
        {
            var data = _mapper.Map<IEnumerable<Product>>(_dataAccess.List()).ToArray();

            var rng = new Random();
            var n = rng.Next(1, data.Count());
            var sample = Enumerable
                .Range(0, n)
                .Select(x => rng.Next(0, 1 + data.Count() - n))
                .OrderBy(x => x)
                .Select((x, i) => data[x + i])
                .ToArray();

            return sample.ToList();

        }
    }
}
