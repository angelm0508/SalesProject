using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.supplier.supplier
{
    public class SupplierCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        [MinLength(9, ErrorMessage = "{0} must be have at least {1} characters")]
        public string Nit { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CategoryId { get; set; }
    }
}
