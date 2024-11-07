using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Auth;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Application.Services.Auth;
using LinkDev.Talabat.Core.Application.Services.Basket;
using LinkDev.Talabat.Core.Application.Services.ProductServiceNS;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LinkDev.Talabat.Core.Application.Services
{
	internal class ServiceManager : IServiceManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;
		private readonly Lazy<IBasketService> _basketService;
		private readonly Lazy<IAuthService> _authService;
		private readonly Lazy<IProductService> _productService;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, Func<IBasketService> basketServiceFactry, Func<IAuthService> AuthServiceFactry, IHttpContextAccessor httpContext)
        {
			_mapper = mapper;
			_configuration = configuration;
			_unitOfWork = unitOfWork;
			_productService = new Lazy<IProductService>(()=> new ProductService(unitOfWork, mapper, httpContext));
			_authService = new Lazy<IAuthService>(AuthServiceFactry);
			_basketService = new Lazy<IBasketService>(basketServiceFactry);
		}
        public IProductService ProductService => _productService.Value;

		public IBasketService BasketService => _basketService.Value;
		public IAuthService AuthService => _authService.Value;

	}
}