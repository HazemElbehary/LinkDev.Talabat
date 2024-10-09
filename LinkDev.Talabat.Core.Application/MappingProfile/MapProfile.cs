using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs;
using LinkDev.Talabat.Core.Domain.Entities.Product;

namespace LinkDev.Talabat.Core.Application.MappingProfile
{
	internal class MapProfile : Profile
	{
        public MapProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(src => src.Brand!.Name))
				.ForMember(d => d.Category, O => O.MapFrom(src => src.Category!.Name));

            CreateMap<ProductCategory, CategoryToReturnDto>();
            CreateMap<ProductBrand, BrandToReturnDto>();
        }
    }
}
