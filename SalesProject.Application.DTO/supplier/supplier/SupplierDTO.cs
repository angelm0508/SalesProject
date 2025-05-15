using SalesProject.Application.DTO.supplier.category;

namespace SalesProject.Application.DTO.supplier.supplier
{
    public class SupplierDTO
    {
        public string Code { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public SupplierCatDTO Category { get; set; }
    }
}
