namespace SalesProject.Application.DTO.sale.sale
{
    public class SaleUpdateDTO
    {
        public int TransStateId { get; set; }

        public bool Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
    }
}
