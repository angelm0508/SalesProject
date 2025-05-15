using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.sale_order.sale_order_detail
{
    public class SaleOrderDetCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string ProductSku { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }

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
