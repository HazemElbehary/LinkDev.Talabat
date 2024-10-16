using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Application.Services.Basket;
using LinkDev.Talabat.Core.Application.Services.ProductServiceNS;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;
using Microsoft.Extensions.Configuration;

namespace LinkDev.Talabat.Core.Application.Services
{
	internal class ServiceManager : IServiceManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;
		private readonly Lazy<IBasketService> _basketService;
		Lazy<ProductService> _productService;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, Func<IBasketService> basketServiceFactry)
        {
			_mapper = mapper;
			_configuration = configuration;
			_unitOfWork = unitOfWork;
			_productService = new Lazy<ProductService>(()=> new ProductService(unitOfWork, mapper));
			_basketService = new Lazy<IBasketService>(basketServiceFactry);

		}
        public IProductService ProductService => _productService.Value;

		public IBasketService BasketService => _basketService.Value;

	}
}