using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public string CustomerCode { get; set; }

    public string UserCode { get; set; }

    public int TransStateId { get; set; }

    public int? SaleOrderId { get; set; }

    public int NoDoc { get; set; }

    public string Serie { get; set; }

    public bool Credit { get; set; }

    public int? CreditDays { get; set; }

    public DateTime DateTrans { get; set; }

    public DateTime Date { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Iva { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<BatchTransaction> BatchTransactions { get; } = new List<BatchTransaction>();

    public virtual Customer CustomerCodeNavigation { get; set; }

    public virtual Document Document { get; set; }

    public virtual ICollection<SaleDet> SaleDets { get; set; } = new List<SaleDet>();

    public virtual SaleOrder SaleOrder { get; set; }

    public virtual ICollection<SaleReturnDet> SaleReturnDets { get; } = new List<SaleReturnDet>();

    public virtual TransactionState TransState { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();

    public virtual UserSy UserCodeNavigation { get; set; }
}
