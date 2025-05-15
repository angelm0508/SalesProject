using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class SaleReturnDet
{
    public int Id { get; set; }

    public int SaleReturnId { get; set; }

    public int SaleId { get; set; }

    public string ProductSku { get; set; }

    public string Name { get; set; }

    public string CellarCode { get; set; }

    public decimal? Price { get; set; }

    public decimal Units { get; set; }

    public decimal Discount { get; set; }

    public decimal SubTotal { get; set; }

    public virtual Cellar CellarCodeNavigation { get; set; }

    public virtual Product ProductSkuNavigation { get; set; }

    public virtual Sale Sale { get; set; }

    public virtual SaleReturn SaleReturn { get; set; }
}
