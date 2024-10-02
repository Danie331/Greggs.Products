using Greggs.Products.Services.Models;
using MediatR;

namespace Greggs.Products.Api.CQRS.Query.UseCases
{
    public class GetProductsSortedByDateQuery : IRequest<PaginatedList<Product>>
    {
        public int? PageStart { get; }
        public int? PageSize { get; }
        public GetProductsSortedByDateQuery(int? pageStart, int? pageSize)
        {
            PageStart = pageStart;
            PageSize = pageSize;
        }
    }
}
