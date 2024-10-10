using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Employees;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Application.Services.EmployeesService;
using LinkDev.Talabat.Core.Application.Services.ProductServiceNS;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;

namespace LinkDev.Talabat.Core.Application.Services
{
	internal class ServiceManager : IServiceManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		Lazy<ProductService> productService;
		Lazy<EmployeeService> employeeService;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			productService = new Lazy<ProductService>(()=> new ProductService(unitOfWork, mapper));
			employeeService = new Lazy<EmployeeService>(()=> new EmployeeService(unitOfWork, mapper));
		}
        public IProductService ProductService => productService.Value;
        public IEmployeeService EmployeeService => employeeService.Value;
	}
}