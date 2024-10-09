using AutoMapper;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Employee;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Employees;
using LinkDev.Talabat.Core.Domain.Entities.Employee;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;
using LinkDev.Talabat.Core.Domain.Specifications.Employees;

namespace LinkDev.Talabat.Core.Application.Services.EmployeesService
{
	internal class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeService
	{
		public async Task<EmployeeToReturnDto> GetEmployeeAsync(int id)
		{
			var spec = new EmployeeWithDepartmentSpecification();
			
			var employee = await unitOfWork.GetRepository<Employee, int>().GetWithSpecAsync(spec);

			var employeeToReturnDto = mapper.Map<EmployeeToReturnDto>(employee);

			return employeeToReturnDto;
		}

		public async Task<IEnumerable<EmployeeToReturnDto>> GetEmployeesAsync()
		{
			var spec = new EmployeeWithDepartmentSpecification();


			var employees = await unitOfWork.GetRepository<Employee, int>().GetAllWithSpecAsync(spec);

			var employeeToReturnDto = mapper.Map<IEnumerable<EmployeeToReturnDto>>(employees);

			return employeeToReturnDto;
		}
	

	}
}
