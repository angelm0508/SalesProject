using SalesProject.Application.DTO.buy.buy_detail;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.buy.buy
{
    public class BuyCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empt.")]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public string SupplierCode { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public string UserCode { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public int TransStateId { get; set; }

        public int? BuyOrderId { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public int NoDoc { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public bool Credit { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public int CreditDays { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public DateTime DateTrans { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public double SubTotal { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public double Iva { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "{0} must not be empt.")]
        public List<BuyDetCreateDTO> BuyDets { get; set; }
    }
}
