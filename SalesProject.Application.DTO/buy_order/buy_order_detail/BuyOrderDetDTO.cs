namespace SalesProject.Application.DTO.buy_order.buy_order_detail
{
    public class BuyOrderDetDTO
    {
        public int Id { get; set; }
        public int BuyOrderId { get; set; }
        public string ProductSku { get; set; }
        public string Name { get; set; }
        public string CellarCode { get; set; }
        public double Price { get; set; }
        public double Units { get; set; }  
        public double Discount { get; set; }
        public double SubTotal { get; set; }   
    }
}
