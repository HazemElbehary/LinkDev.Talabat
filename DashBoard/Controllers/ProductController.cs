﻿using DashBoard.Helper;
using DashBoard.Models.ProductViewModel;
using LinkDev.Talabat.Core.Application.Abstraction.DTOs.Product;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services.Product;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController(IServiceManager serviceManager) : Controller
    {
        public async  Task<IActionResult> Index()
        {
            var products = await serviceManager.ProductService.GetProductsAsync(null, null, null, 10000, 1, null);

            var mappedProducts = products.Data.Select(P => new ProductViewModel
            {
                Id = P.Id,
                Name = P.Name,
                Description = P.Description,
                Price = P.Price,
                PictureUrl = P.PictureUrl,
                Brand = P.Brand,
                Category = P.Category
            });

            return View(mappedProducts);
        }
    
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Create(ProductViewModel model)
        {
            await FileIOHelper.UploadAsync(model.Picture, "images/products");

            var ProducttoAdd = new CreateProductDto() 
            {
                Name = model.Name,
                Description= model.Description,
                Price = model.Price,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                PictureUrl = model.PictureUrl
            };

            await serviceManager.ProductService.AddProductAsync(ProducttoAdd);

            return RedirectToAction(nameof(Index));
		}
	
        public async Task<IActionResult> Edit(int id)
        {
			var product = await serviceManager.ProductService.GetProductAsync(id);
			var mappedProduct = new ProductViewModel
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				PictureUrl = product.PictureUrl,
				BrandId = product.BrandId,
				CategoryId = product.CategoryId,
				Brand = product.Brand,
				Category = product.Category
			};
			return View(mappedProduct);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ProductViewModel model)
        {
            var mappedProduct = new UpdateProductDto() 
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CategoryId= model.CategoryId,
                BrandId= model.BrandId,
                Price = model.Price,
                PictureUrl = model.PictureUrl
            };

            await serviceManager.ProductService.UpdateProduct(mappedProduct);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
        {
            var product = await serviceManager.ProductService.GetProductAsync(id);
			var mappedProduct =  new ProductViewModel
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				PictureUrl = product.PictureUrl,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
				Brand = product.Brand,
				Category = product.Category
			};
			return View(mappedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewModel model)
        {
            await serviceManager.ProductService.DeleteProduct(model.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
