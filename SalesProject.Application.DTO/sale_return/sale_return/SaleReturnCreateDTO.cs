using SalesProject.Application.DTO.sale_return.sale_return_det;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.sale_return.sale_return
{
    public class SaleReturnCreateDTO
    {
        public int DocumentId { get; set; }
        public string CustomerCode { get; set; }
        public string UserCode { get; set; }
        public int TransStateId { get; set; }
        public int NoDoc { get; set; }
        public string Serie { get; set; }
        public bool Credit { get; set; }
        public DateTime DateTrans { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        [MinLength(3, ErrorMessage = "{0} must be at least 3 characters.")]
        public string Observation { get; set; }
        public double Subtotal { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
        public List<SaleReturnDetCreateDTO> SaleReturnDets { get; set; }
    }
}
