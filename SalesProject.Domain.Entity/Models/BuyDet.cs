using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BuyDet
{
    public int Id { get; set; }

    public int BuyId { get; set; }

    public string ProductSku { get; set; }

    public string Name { get; set; }

    public string CellarCode { get; set; }

    public decimal? Price { get; set; }

    public decimal Units { get; set; }

    public decimal? Discount { get; set; }

    public decimal SubTotal { get; set; }

    public virtual Buy Buy { get; set; }

    public virtual Cellar CellarCodeNavigation { get; set; }

    public virtual Product ProductSkuNavigation { get; set; }
}
