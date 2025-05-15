namespace SalesProject.Application.DTO.sale_return.sale_return
{
    public class SaleReturnUpdateDTO
    { 
        public int TransStateId { get; set; }
        public bool Credit { get; set; }
        public DateTime DateTrans { get; set; }
        public string Observation { get; set; }
    }
}
