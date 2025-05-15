namespace SalesProject.Application.DTO.buy_return.buy_return_detail
{
    public class BuyReturnDetDTO
    {
        public int Id { get; set; }
        public int BuyId { get; set; }
        public string ProductSku { get; set; }
        public string CellarCode { get; set; }
        public double Price { get; set; }
        public double Units { get; set; } 
        public double Discount { get; set; }
        public double Subtotal { get; set; }
    }
}
