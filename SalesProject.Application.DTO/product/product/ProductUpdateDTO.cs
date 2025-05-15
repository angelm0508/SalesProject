namespace SalesProject.Application.DTO.product.product
{
    public class ProductUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public int StatusId { get; set; }
        public int CategoryId { get; set; }
        public int MeasureId { get; set; }
        public int BrandId { get; set; }
    }
}
