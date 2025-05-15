namespace SalesProject.Application.DTO.product.batch
{
    public class BatchProductCreateDTO
    {
        public string Sku { get; set; }

        public int SysNumber { get; set; }

        public string DistNumber { get; set; }

        public string MnfSerial { get; set; }

        public string LotNumber { get; set; }

        public DateTime? InDate { get; set; }

        public DateTime? ExpDate { get; set; }

        public DateTime? GrntStart { get; set; }

        public DateTime? GrntExp { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Status { get; set; }

        public string Details { get; set; }
    }
}
