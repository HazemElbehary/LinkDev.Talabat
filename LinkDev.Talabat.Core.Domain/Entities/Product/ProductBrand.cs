﻿using LinkDev.Talabat.Core.Domain.Common;

namespace LinkDev.Talabat.Core.Domain.Entities.Product
{
    public class ProductBrand : BaseEntity<int>
    {
        public required string Name { get; set; }
    }
}