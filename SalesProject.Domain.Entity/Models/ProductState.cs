using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class ProductState
{
    public byte Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
