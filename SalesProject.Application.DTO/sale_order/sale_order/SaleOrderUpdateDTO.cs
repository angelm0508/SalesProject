namespace SalesProject.Application.DTO.sale_order.sale_order
{
    public class SaleOrderUpdateDTO
    {
        public int OutputDocumentId { get; set; }
        public bool Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
      
    }
}
