namespace SalesProject.Application.DTO.sale_order.sale_order_detail
{
    public class SaleOrderDetDTO
    {
        public int Id { get; set; }
        public int SaleOrderId { get; set; }
        public string ProductSku { get; set; }
        public string Name { get; set; }
        public string CellarCode { get; set; }
        public double Price { get; set; }
        public double Units { get; set; }
        public double Discount { get; set; }
        public double Subtotal { get; set; }
    }
}
