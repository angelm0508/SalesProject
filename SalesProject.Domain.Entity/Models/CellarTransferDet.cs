using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class CellarTransferDet
{
    public int Id { get; set; }

    public int CellarTransId { get; set; }

    public string ProductSku { get; set; }

    public string CellarOriginCode { get; set; }

    public string CellarDestinationCode { get; set; }

    public decimal Quantity { get; set; }

    public virtual Cellar CellarDestinationCodeNavigation { get; set; }

    public virtual Cellar CellarOriginCodeNavigation { get; set; }

    public virtual CellarTransfer CellarTrans { get; set; }

    public virtual Product ProductSkuNavigation { get; set; }
}
