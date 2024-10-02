using Greggs.Products.Api.CQRS.Query.UseCases;
using Greggs.Products.Services.Contract;
using Greggs.Products.Services.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Greggs.Products.Api.CQRS.Query.Handlers
{
    public class GetProductsSortedByDateQueryHandler : IRequestHandler<GetProductsSortedByDateQuery, PaginatedList<Product>>
    {
        private readonly IProductsService _productsService;
        private readonly ILogger<GetProductsSortedByDateQueryHandler> _logger;
        public GetProductsSortedByDateQueryHandler(IProductsService productsService, ILogger<GetProductsSortedByDateQueryHandler> logger)
        {
            _productsService = productsService;
            _logger = logger;
        }

        public Task<PaginatedList<Product>> Handle(GetProductsSortedByDateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_productsService.GetProductsSortedByDate(request.PageStart, request.PageSize));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal error occurred");
                throw;
            }
        }
    }
}
