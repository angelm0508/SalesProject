namespace SalesProject.Application.DTO.sale.sale_detail
{
    public class SaleDetDTO
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public string ProductSku { get; set; }
        public string CellarCode { get; set; }
        public double Price { get; set; }
        public double Units { get; set; }
        public double Discount { get; set; }
        public double Subtotal { get; set; }   
    }
}
