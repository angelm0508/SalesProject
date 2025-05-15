using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BuyReturnDet
{
    public int Id { get; set; }

    public int BuyReturnId { get; set; }

    public int BuyId { get; set; }

    public string ProductSku { get; set; }

    public string Name { get; set; }

    public string CellarCode { get; set; }

    public decimal? Price { get; set; }

    public decimal Units { get; set; }

    public decimal Discount { get; set; }

    public decimal SubTotal { get; set; }

    public virtual BuyReturn BuyReturn { get; set; }

    public virtual Cellar CellarCodeNavigation { get; set; }

    public virtual Product ProductSkuNavigation { get; set; }
}
