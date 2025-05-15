using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.buy.buy_detail
{
    public class BuyDetUpdateDTO
    {
        public string ProductSku { get; set; }
        public string CellarCode { get; set; }
        public double Price { get; set; }
        public int Units { get; set; }
        public double Discount { get; set; }
        public double Subtotal { get; set; }
    }
}
