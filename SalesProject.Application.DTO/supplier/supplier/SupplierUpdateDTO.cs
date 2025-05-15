using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.supplier.supplier
{
    public class SupplierUpdateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Nit { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CategoryId { get; set; }
    }
}
