using SalesProject.Application.DTO.product.brand;
using SalesProject.Application.DTO.product.category;
using SalesProject.Application.DTO.product.measure;
using SalesProject.Application.DTO.product.status;

namespace SalesProject.Application.DTO.product.product
{
    public class ProductDTO
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public ProductStateDTO Status { get; set; }
        public ProductCatDTO Category { get; set; }
        public ProductMeasureDTO Measure { get; set; }
        public ProductBrandDTO Brand { get; set; }
    }
}
