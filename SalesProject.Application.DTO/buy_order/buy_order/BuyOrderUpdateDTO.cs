namespace SalesProject.Application.DTO.buy_order.buy_order
{
    public class BuyOrderUpdateDTO
    {
        public int OutputDocumentId { get; set; }
        public bool Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
    }
}
