using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.product.product
{
    public class ProductCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal BuyPrice { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public byte StatusId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int MeasureId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int BrandId { get; set; }
    }
}
