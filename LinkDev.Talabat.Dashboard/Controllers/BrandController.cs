using LinkDev.Talabat.Core.Domain.Entities.Product;
using LinkDev.Talabat.Core.Domain.NIUnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.Dashboard.Controllers
{
    public class BrandController(IUnitOfWork unitOfWork) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            return View(brands);
        }
    
        public async Task<IActionResult> Create(ProductBrand brand)
        {
            try
            {
                await unitOfWork.GetRepository<ProductBrand, int>().AddAsync(brand);
                await unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("Name", "Please Enter Other Name")
                return View("Index", await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync());
            }
        }
    
        public async Task<IActionResult> Delete(int id)
        {
            var brand = unitOfWork.GetRepository<ProductBrand, int>().GetAsync(id);
            unitOfWork.GetRepository<ProductBrand, int>().Delete(brand);
            await unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
