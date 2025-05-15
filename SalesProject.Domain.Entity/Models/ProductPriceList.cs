using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class ProductPriceList
{
    public int Id { get; set; }

    public string ListName { get; set; }

    public int? BaseList { get; set; }

    public decimal? Factor { get; set; }

    public byte? RoundSys { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
