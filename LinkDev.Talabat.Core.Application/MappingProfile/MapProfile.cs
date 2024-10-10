using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Employee;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Product;
using LinkDev.Talabat.Core.Domain.Entities.Employee;
using LinkDev.Talabat.Core.Domain.Entities.Product;

namespace LinkDev.Talabat.Core.Application.MappingProfile
{
    internal class MapProfile : Profile
	{
        public MapProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(src => src.Brand!.Name))
				.ForMember(d => d.Category, O => O.MapFrom(src => src.Category!.Name))
				.ForMember(d => d.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());

            CreateMap<ProductCategory, CategoryToReturnDto>();
            CreateMap<ProductBrand, BrandToReturnDto>();
            CreateMap<Employee, EmployeeToReturnDto>();
        }
    }
}
