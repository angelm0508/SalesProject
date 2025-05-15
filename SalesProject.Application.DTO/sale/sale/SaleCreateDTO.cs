using SalesProject.Application.DTO.sale.sale_detail;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.sale.sale
{
    public class SaleCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string CustomerCode { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string UserCode { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int TransStateId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int? SaleOrderId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int NoDoc { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public bool Credit { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CreditDays { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public DateTime DateTrans { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Subtotal { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Iva { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public List<SaleDetCreateDTO> SaleDets { get; set; }

    }
}
