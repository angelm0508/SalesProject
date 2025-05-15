using SalesProject.Application.DTO.customer.category;

namespace SalesProject.Application.DTO.customer.customer
{
    public class CustomerDTO
    {
        public string Code { get; set; }
        public string Nit { get; set; }
        public string Cui { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public bool Defaulter { get; set; }
        public CustomerCatDTO Category { get; set; }
    }
}
