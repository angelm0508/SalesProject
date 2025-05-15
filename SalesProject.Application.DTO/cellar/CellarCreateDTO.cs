using System.ComponentModel.DataAnnotations;

namespace SalesProject.Application.DTO.cellar
{
    public class CellarCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
