﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Employee;

namespace LinkDev.Talabat.Core.Application.Abstraction.Services.Employees
{
    public interface IEmployeeService
	{
		Task<IEnumerable<EmployeeToReturnDto>> GetEmployeesAsync();

		Task<EmployeeToReturnDto> GetEmployeeAsync(int id);
	}
}