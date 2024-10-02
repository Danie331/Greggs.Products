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
    public class GetRandomSelectionQueryHandler : IRequestHandler<GetRandomSelectionQuery, PaginatedList<Product>>
    {
        private readonly IProductsService _productsService;
        private readonly ILogger<GetRandomSelectionQueryHandler> _logger;
        public GetRandomSelectionQueryHandler(IProductsService productsService, ILogger<GetRandomSelectionQueryHandler> logger)
        {
            _productsService = productsService;
            _logger = logger;
        }

        public Task<PaginatedList<Product>> Handle(GetRandomSelectionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(_productsService.GetRandomSelection(request.PageStart, request.PageSize));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal error occurred");
                throw;
            }
        }
    }
}