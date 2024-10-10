using LinkDev.Talabat.Core.Domain.Entities.Employee;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories.GenericRepositories;

namespace LinkDev.Talabat.Core.Domain.Specifications.Employees
{
	public class EmployeeWithDepartmentSpecification : BaseISpecifications<Employee, int>
	{
		public EmployeeWithDepartmentSpecification() : base()
		{
			Includes.Add(E => E.Department!);
		}

		public EmployeeWithDepartmentSpecification(int id) : base(id)
		{
			Includes.Add(E => E.Department!);
		}
	}
}
