namespace SalesProject.Application.DTO.product.min_max
{
    public class MinMaxProductUnitsDTO
    {
        public int Id { get; set; }
        public string ProductSku { get; set; }
        public string CellarCode { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }

    }
}
