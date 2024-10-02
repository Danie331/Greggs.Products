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

        public PaginatedList<Product> GetProductsInCurrency(string currency, int? pageStart, int? pageSize)
        {
            // Contrived lookup - would normally fetch these values from a data source externally
            var currencyLookup = new Dictionary<string, decimal>() { { "EUR", 1.11m } };

            if (!currencyLookup.Keys.Any(k => k.ToLower().Equals(currency.ToLower())))
            {
                throw new ArgumentException("Currency not found");
            }

            var exchangeRate = currencyLookup[currency.ToUpper()];
            var data = _mapper.Map<List<Product>>(_dataAccess.List());

            foreach (var item in data)
            {
                item.PriceInEuros = item.PriceInPounds * exchangeRate;
            }

            return PaginateResults(() => data, pageStart, pageSize);
        }

        public PaginatedList<Product> GetProductsSortedByDate(int? pageStart, int? pageSize)
        {
            var data = _mapper.Map<List<Product>>(_dataAccess.List().OrderByDescending(product => product.DateAdded)); // The filtering could be added into the data layer
            return PaginateResults(() => data, pageStart, pageSize);
        }    

        public PaginatedList<Product> GetRandomSelection(int? pageStart, int? pageSize)
        {
            var data = _mapper.Map<IEnumerable<Product>>(_dataAccess.List()).ToArray();
            var random = new Random();
            var n = random.Next(1, data.Count());
            var sample = Enumerable
                .Range(0, n)
                .Select(x => random.Next(0, 1 + data.Count() - n))
                .OrderBy(x => x)
                .Select((x, i) => data[x + i])
                .ToArray();

            return PaginateResults(() => sample.ToList(), pageStart, pageSize);
        }

        private PaginatedList<Product> PaginateResults(Func<List<Product>> dataFetcher, int? pageStart, int? pageSize)
        {
            var data = dataFetcher();
            var count = data.Count;
            if (pageStart.HasValue && pageSize.HasValue)
            {
                var pagedData = data.Skip((pageStart.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
                var totalPages = (int)Math.Ceiling(count / (double)pageSize.Value);

                return new PaginatedList<Product>(pagedData, pageStart.Value, pageSize.Value, totalPages, count);
            }

            return new PaginatedList<Product>(data, 1, count, 1, count);
        }
    }
}
