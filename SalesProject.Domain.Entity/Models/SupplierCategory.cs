using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class SupplierCategory
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
