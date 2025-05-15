using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class TransactionState
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<BuyOrder> BuyOrders { get; } = new List<BuyOrder>();

    public virtual ICollection<BuyReturn> BuyReturns { get; } = new List<BuyReturn>();

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();

    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    public virtual ICollection<SaleReturn> SaleReturns { get; } = new List<SaleReturn>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
