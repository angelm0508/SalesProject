namespace SalesProject.Application.DTO.buy_return.buy_return
{
    public class BuyReturnUpdateDTO
    {
        public bool Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
        public string Observation { get; set; }
    }
}
