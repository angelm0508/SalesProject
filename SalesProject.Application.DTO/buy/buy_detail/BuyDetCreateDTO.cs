using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.buy.buy_detail
{
    public class BuyDetCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empt.")]
        public string ProductSku { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public string CellarCode { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public double Units { get; set; }
        public double Discount { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public double Subtotal { get; set; }
    }
}
