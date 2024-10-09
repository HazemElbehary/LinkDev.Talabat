using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services
{
	public interface IServiceManager
	{
        public IProductService ProductService { get; }
    }
}
