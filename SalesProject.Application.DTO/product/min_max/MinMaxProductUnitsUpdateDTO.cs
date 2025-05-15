using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.product.min_max
{
    public class MinMaxProductUnitsUpdateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string ProductSku { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string CellarCode { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int Minimum { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int Maximum { get; set; }
    }
}
