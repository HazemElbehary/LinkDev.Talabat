using AutoMapper;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Dashboard.Models;

namespace LinkDev.Talabat.Dashboard.Helpers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
