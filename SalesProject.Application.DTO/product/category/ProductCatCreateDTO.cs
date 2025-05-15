using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.product.category
{
    public class ProductCatCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }
}
