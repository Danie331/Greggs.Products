using Greggs.Products.Services.Models;
using MediatR;

namespace Greggs.Products.Api.CQRS.Query.UseCases
{
    public class GetProductsInCurrencyQuery : IRequest<PaginatedList<Product>>
    {
        public string Currency { get; }
        public int? PageStart { get; }
        public int? PageSize { get; }
        public GetProductsInCurrencyQuery(string currency, int? pageStart, int? pageSize)
        {
            PageStart = pageStart;
            PageSize = pageSize;
            Currency = currency;
        }
    }
}
