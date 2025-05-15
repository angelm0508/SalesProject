using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class TransactionDetail
{
    public int Id { get; set; }

    public int? BuyId { get; set; }

    public int? SaleId { get; set; }

    public int? BuyReturnId { get; set; }

    public int? SaleReturnId { get; set; }

    public int? CellarTransferId { get; set; }

    public string ProductSku { get; set; }

    public string CellarCode { get; set; }

    public decimal Units { get; set; }

    public DateTime Date { get; set; }

    public decimal Value { get; set; }

    public string NoDoc { get; set; }

    public virtual Buy Buy { get; set; }

    public virtual BuyReturn BuyReturn { get; set; }

    public virtual Cellar CellarCodeNavigation { get; set; }

    public virtual CellarTransfer CellarTransfer { get; set; }

    public virtual Product ProductSkuNavigation { get; set; }

    public virtual Sale Sale { get; set; }

    public virtual SaleReturn SaleReturn { get; set; }
}
