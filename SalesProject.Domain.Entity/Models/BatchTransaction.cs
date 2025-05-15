using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BatchTransaction
{
    public int Id { get; set; }

    public string Sku { get; set; }

    public string DistNumber { get; set; }

    public decimal? Quantity { get; set; }

    public int? BuyOrderId { get; set; }

    public int? BuyId { get; set; }

    public int? BuyReturnId { get; set; }

    public int? SaleOrderId { get; set; }

    public int? SaleId { get; set; }

    public int? SaleReturnId { get; set; }

    public bool? Direction { get; set; }

    public virtual Buy Buy { get; set; }

    public virtual BuyOrder BuyOrder { get; set; }

    public virtual BuyReturn BuyReturn { get; set; }

    public virtual Sale Sale { get; set; }

    public virtual SaleOrder SaleOrder { get; set; }

    public virtual SaleReturn SaleReturn { get; set; }

    public virtual Product SkuNavigation { get; set; }
}
