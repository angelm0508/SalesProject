namespace SalesProject.Application.DTO.sale_return.sale_return_det
{
    public class SaleReturnDetDTO
    {
        public int Id { get; set; }
        public int SaleReturnId { get; set; }
        public int SaleId { get; set; }
        public string ProductSku { get; set; }
        public string CellarCode { get; set; }
        public double Price { get; set; }
        public double Units { get; set; }
        public double Discount { get; set; }
        public double Subtotal { get; set; }

    }
}
