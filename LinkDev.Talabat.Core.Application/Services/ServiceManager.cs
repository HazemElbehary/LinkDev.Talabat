using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Application.Services.ProductServiceNS;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;

namespace LinkDev.Talabat.Core.Application.Services
{
	internal class ServiceManager : IServiceManager
	{
		Lazy<ProductService> productService;

        public ServiceManager(IUnitOfWork unitOfWork, Mapper mapper)
        {
			productService = new Lazy<ProductService>(()=> new ProductService(unitOfWork, mapper));
        }
        public IProductService ProductService => productService.Value;
	}
}