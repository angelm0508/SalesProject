using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class RolUser
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<UserSy> UserSies { get; } = new List<UserSy>();
}
