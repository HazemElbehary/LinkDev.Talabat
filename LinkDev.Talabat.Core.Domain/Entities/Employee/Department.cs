﻿using LinkDev.Talabat.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Entities.Employee
{
	public class Department : BaseAuditableEntity<int>
	{
        public required string Name { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}