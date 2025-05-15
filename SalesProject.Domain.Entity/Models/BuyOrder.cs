using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BuyOrder
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public string SupplierCode { get; set; }

    public string UserCode { get; set; }

    public int TransStateId { get; set; }

    public int OutputDocumentId { get; set; }

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

    public virtual ICollection<BuyOrderDet> BuyOrderDets { get; } = new List<BuyOrderDet>();

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();

    public virtual Document Document { get; set; }

    public virtual Document OutputDocument { get; set; }

    public virtual Supplier SupplierCodeNavigation { get; set; }

    public virtual TransactionState TransState { get; set; }

    public virtual UserSy UserCodeNavigation { get; set; }
}
