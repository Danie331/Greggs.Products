using Greggs.Products.Services.Models;
using MediatR;

namespace Greggs.Products.Api.CQRS.Query.UseCases
{
    public class GetRandomSelectionQuery : IRequest<PaginatedList<Product>>
    {
        public int PageStart { get; }
        public int PageSize { get; }

        public GetRandomSelectionQuery(int pageStart, int pageSize)
        {
            PageStart = pageStart;
            PageSize = pageSize;
        }
    }
}
