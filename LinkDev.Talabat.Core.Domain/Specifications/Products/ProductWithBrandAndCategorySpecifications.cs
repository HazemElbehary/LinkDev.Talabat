﻿using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories.GenericRepositories;

namespace LinkDev.Talabat.Core.Domain.Specifications.Products
{
	public class ProductWithBrandAndCategorySpecifications : BaseISpecifications<Product, int>
	{
        public ProductWithBrandAndCategorySpecifications(string? sort) : base()
		{
			AddIncludes();

			AddOrderBy(p => p.Name);

			if (!string.IsNullOrEmpty(sort))
			{
				switch (sort)
				{
					case "nameDesc":
						AddOrderByDesc(p => p.Name);
						break;
					case "priceAsc":
						AddOrderBy(P => P.Price);
						break;
					case "priceDesc":
						AddOrderByDesc(P => P.Price);
						break;
					default:
						AddOrderBy(p => p.Name);
						break;
				} 
			}
		}

		public ProductWithBrandAndCategorySpecifications(int id) : base(id)
        {
			Criteria = P => P.Id == id;
			AddIncludes();
		}

		#region Helpers

		private protected override void AddIncludes()
		{
			base.AddIncludes();

			Includes.Add(P => P.Brand!);
			Includes.Add(P => P.Category!);
		}

		#endregion
	}
}