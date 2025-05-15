using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class CustomerCategory
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
