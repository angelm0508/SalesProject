using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class MinMaxProduct
{
    public int Id { get; set; }

    public string ProductSku { get; set; }

    public string CellarCode { get; set; }

    public int Minimum { get; set; }

    public int Maximum { get; set; }

    public virtual Cellar CellarCodeNavigation { get; set; }

    public virtual Product ProductSkuNavigation { get; set; }
}
