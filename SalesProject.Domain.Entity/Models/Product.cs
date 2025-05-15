using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Product
{
    public string Sku { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal? BuyPrice { get; set; }

    public int? Stock { get; set; }

    public int? CategoryId { get; set; }

    public byte? StatusId { get; set; }

    public int? MeasureId { get; set; }

    public int? BrandId { get; set; }

    public int? PriceList { get; set; }

    public virtual ICollection<BatchProduct> BatchProducts { get; } = new List<BatchProduct>();

    public virtual ICollection<BatchTransaction> BatchTransactions { get; } = new List<BatchTransaction>();

    public virtual ProductBrand Brand { get; set; }

    public virtual ICollection<BuyDet> BuyDets { get; } = new List<BuyDet>();

    public virtual ICollection<BuyOrderDet> BuyOrderDets { get; } = new List<BuyOrderDet>();

    public virtual ICollection<BuyReturnDet> BuyReturnDets { get; } = new List<BuyReturnDet>();

    public virtual ProductCategory Category { get; set; }

    public virtual ICollection<CellarTransferDet> CellarTransferDets { get; } = new List<CellarTransferDet>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ProductMeasure Measure { get; set; }

    public virtual ICollection<MinMaxProduct> MinMaxProducts { get; } = new List<MinMaxProduct>();

    public virtual ProductPriceList PriceListNavigation { get; set; }

    public virtual ICollection<SaleDet> SaleDets { get; } = new List<SaleDet>();

    public virtual ICollection<SaleOrderDet> SaleOrderDets { get; } = new List<SaleOrderDet>();

    public virtual ICollection<SaleReturnDet> SaleReturnDets { get; } = new List<SaleReturnDet>();

    public virtual ProductState Status { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();
}
