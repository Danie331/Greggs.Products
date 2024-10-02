using AutoMapper;
using Domain = Greggs.Products.Services.Models;
using Data = Greggs.Products.Persistence.Entities;
using ApiDto = Greggs.Products.Api.Models;

namespace Greggs.Products.Api.Automapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() 
        {
            CreateMap<Data.Product, Domain.Product>();
            CreateMap<Domain.Product, ApiDto.Product>();
            CreateMap(typeof(Domain.PaginatedList<>), typeof(ApiDto.PaginatedList<>));
        }
    }
}
