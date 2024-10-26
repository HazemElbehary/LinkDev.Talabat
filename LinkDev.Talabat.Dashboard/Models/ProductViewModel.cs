using LinkDev.Talabat.Core.Domain.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace LinkDev.Talabat.Dashboard.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description Is Required")]

        public string Description { get; set; }
        public FormFile Image { get; set; }
        public string? PictureUrl { get; set; }
        [Required(ErrorMessage = "Price Is Required")]
        [Range(1, 100000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "ProductCategoryId Is Required")]
        public int ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        
        [Required(ErrorMessage = "ProductBrandId Is Required")]
        public int ProductBrandId { get; set; }
        public ProductBrand? ProductBrand { get; set; }

    }
}
