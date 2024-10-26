using AutoMapper;
using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;
using LinkDev.Talabat.Dashboard.Helpers;
using LinkDev.Talabat.Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace LinkDev.Talabat.Dashboard.Controllers
{
    public class ProductController(IUnitOfWork unitOfWork, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var Products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();

            var mappedProducts = mapper.Map<IReadOnlyList<ProductViewModel>>(Products);

            return View(mappedProducts);
        }
    

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.Image != null)
                    model.PictureUrl = PictureSettings.UploadFile(model.Image, "products");

                else
                    model.PictureUrl = "images/products/blueberry-cheesecake.png";

                var mappedProduct = mapper.Map<Product>(model);
                await unitOfWork.GetRepository<Product, int>().AddAsync(mappedProduct);
                await unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
            var mappedProduct = mapper.Map<ProductViewModel>(product);
            return View(mappedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,  ProductViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (model.Image != null && model.PictureUrl != null)
                {
                    PictureSettings.DeleteFile(model.PictureUrl, "products");
                    model.PictureUrl = PictureSettings.UploadFile(model.Image, "products");

                }

                else
                    model.PictureUrl = PictureSettings.UploadFile(model.Image, "products");
                var mappedProduct = mapper.Map<Product>(model);
                unitOfWork.GetRepository<Product, int>().Updated(mappedProduct);
                var result = await unitOfWork.Complete();
                if (result > 0)
                    return RedirectToAction(nameof(Index));

            }
            return View(model);
        }
    
        public async Task<IActionResult> Delete(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
            var mappedProduct = mapper.Map<ProductViewModel>(product);
            return View(mappedProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProductViewModel model)
        {
            if (id != model.Id)
                return NotFound();
            try
            {
                var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
                if (product.PictureUrl != null)
                    PictureSettings.DeleteFile(product.PictureUrl, "products");
                unitOfWork.GetRepository<Product, int>().Delete(product);
                await unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch ()
            {
                return View(model);
            }
        }
    }
}
