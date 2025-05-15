using SalesProject.Application.DTO.buy_return.buy_return_detail;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.buy_return.buy_return
{
    public class BuyReturnCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string SupplierCode { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string UserCode { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int TransStateId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int NoDoc { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public bool Credit { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public DateTime DateTrans { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Observation { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Subtotal { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Iva { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public List<BuyReturnDetCreateDTO> BuyReturnDets { get; set; }
    }
}
