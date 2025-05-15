using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.sale.sale_detail;
using SalesProject.Application.DTO.transaction_state;
using SalesProject.Application.DTO.user.user;

namespace SalesProject.Application.DTO.sale.sale
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int? SaleOrderId { get; set; }
        public int NoDoc { get; set; }
        public string Serie { get; set; }
        public bool Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
        public DateTime Date { get; set; }
        public TransactionStateDTO TransState { get; set; }
        public DocumentDTO Document { get; set; }
        public UserDTO User { get; set; }
        public CustomerDTO Customer { get; set; }
        public double Subtotal { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
        public List<SaleDetDTO> SaleDets { get; set; }


    }
}
