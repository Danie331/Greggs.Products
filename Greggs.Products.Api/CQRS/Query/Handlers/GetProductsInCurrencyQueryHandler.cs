using Greggs.Products.Api.CQRS.Query.UseCases;
using Greggs.Products.Services.Contract;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;
using Greggs.Products.Services.Models;

namespace Greggs.Products.Api.CQRS.Query.Handlers
{
    public class GetProductsInCurrencyQueryHandler : IRequestHandler<GetProductsInCurrencyQuery, PaginatedList<Product>>
    {
        private readonly IProductsService _productsService;
        private readonly ILogger<GetProductsInCurrencyQueryHandler> _logger;
        public GetProductsInCurrencyQueryHandler(IProductsService productsService, ILogger<GetProductsInCurrencyQueryHandler> logger)
        {
            _productsService = productsService;
            _logger = logger;
        }

        public Task<PaginatedList<Product>> Handle(GetProductsInCurrencyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_productsService.GetProductsInCurrency(request.Currency, request.PageStart, request.PageSize));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal error occurred");
                throw;
            }
        }
    }
}
