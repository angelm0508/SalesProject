using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.buy_return.buy_return_detail
{
    public class BuyReturnDetCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int BuyId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string ProductSku { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string CellarCode { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Units { get; set; }
        public double Discount { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Subtotal { get; set; }
    }
}
