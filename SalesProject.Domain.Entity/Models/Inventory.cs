using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public string ProductSku { get; set; }

    public string CellarCode { get; set; }

    public decimal Quantity { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual Cellar CellarCodeNavigation { get; set; }

    public virtual Product ProductSkuNavigation { get; set; }
}
