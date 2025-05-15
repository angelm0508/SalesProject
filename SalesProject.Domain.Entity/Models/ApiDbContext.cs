using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models.custom;

namespace SalesProject.Domain.Entity.Models;

public partial class ApiDbContext : DbContext
{
    public ApiDbContext()
    {
    }

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    #region Custom DBSet
    public virtual DbSet<SPCRUD> SPCRUDs { get; set; }
    #endregion

    public virtual DbSet<BatchProduct> BatchProducts { get; set; }

    public virtual DbSet<BatchTransaction> BatchTransactions { get; set; }

    public virtual DbSet<Buy> Buys { get; set; }

    public virtual DbSet<BuyDet> BuyDets { get; set; }

    public virtual DbSet<BuyOrder> BuyOrders { get; set; }

    public virtual DbSet<BuyOrderDet> BuyOrderDets { get; set; }

    public virtual DbSet<BuyReturn> BuyReturns { get; set; }

    public virtual DbSet<BuyReturnDet> BuyReturnDets { get; set; }

    public virtual DbSet<Cellar> Cellars { get; set; }

    public virtual DbSet<CellarTransfer> CellarTransfers { get; set; }

    public virtual DbSet<CellarTransferDet> CellarTransferDets { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerCategory> CustomerCategories { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<MinMaxProduct> MinMaxProducts { get; set; }

    public virtual DbSet<PriceRoundSy> PriceRoundSys { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBrand> ProductBrands { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductMeasure> ProductMeasures { get; set; }

    public virtual DbSet<ProductPriceList> ProductPriceLists { get; set; }

    public virtual DbSet<ProductState> ProductStates { get; set; }

    public virtual DbSet<RolUser> RolUsers { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDet> SaleDets { get; set; }

    public virtual DbSet<SaleOrder> SaleOrders { get; set; }

    public virtual DbSet<SaleOrderDet> SaleOrderDets { get; set; }

    public virtual DbSet<SaleReturn> SaleReturns { get; set; }

    public virtual DbSet<SaleReturnDet> SaleReturnDets { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierCategory> SupplierCategories { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

    public virtual DbSet<TransactionState> TransactionStates { get; set; }

    public virtual DbSet<UserSy> UserSys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=API_DB; User=sa; Password=contra1234; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BatchProduct>(entity =>
        {
            entity.HasKey(e => new { e.Sku, e.SysNumber }).HasName("pk_batch_product");

            entity.ToTable("batch_product");

            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("sku");
            entity.Property(e => e.SysNumber)
                .ValueGeneratedOnAdd()
                .HasColumnName("sys_number");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.Details)
                .HasMaxLength(1024)
                .HasColumnName("details");
            entity.Property(e => e.DistNumber)
                .HasMaxLength(40)
                .HasColumnName("dist_number");
            entity.Property(e => e.ExpDate)
                .HasColumnType("date")
                .HasColumnName("exp_date");
            entity.Property(e => e.GrntExp)
                .HasColumnType("date")
                .HasColumnName("grnt_exp");
            entity.Property(e => e.GrntStart)
                .HasColumnType("date")
                .HasColumnName("grnt_start");
            entity.Property(e => e.InDate)
                .HasColumnType("date")
                .HasColumnName("in_date");
            entity.Property(e => e.LotNumber)
                .HasMaxLength(40)
                .HasColumnName("lot_number");
            entity.Property(e => e.MnfSerial)
                .HasMaxLength(40)
                .HasColumnName("mnf_serial");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");

            entity.HasOne(d => d.SkuNavigation).WithMany(p => p.BatchProducts)
                .HasForeignKey(d => d.Sku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_batch_sku");
        });

        modelBuilder.Entity<BatchTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_batch_transaction");

            entity.ToTable("batch_transaction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyId).HasColumnName("buy_id");
            entity.Property(e => e.BuyOrderId).HasColumnName("buy_order_id");
            entity.Property(e => e.BuyReturnId).HasColumnName("buy_return_id");
            entity.Property(e => e.Direction).HasColumnName("direction");
            entity.Property(e => e.DistNumber)
                .HasMaxLength(40)
                .HasColumnName("dist_number");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
            entity.Property(e => e.SaleReturnId).HasColumnName("sale_return_id");
            entity.Property(e => e.Sku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sku");

            entity.HasOne(d => d.Buy).WithMany(p => p.BatchTransactions)
                .HasForeignKey(d => d.BuyId)
                .HasConstraintName("fk_batch_trans_buy");

            entity.HasOne(d => d.BuyOrder).WithMany(p => p.BatchTransactions)
                .HasForeignKey(d => d.BuyOrderId)
                .HasConstraintName("fk_batch_trans_buy_order");

            entity.HasOne(d => d.BuyReturn).WithMany(p => p.BatchTransactions)
                .HasForeignKey(d => d.BuyReturnId)
                .HasConstraintName("fk_batch_trans_buy_return");

            entity.HasOne(d => d.Sale).WithMany(p => p.BatchTransactions)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("fk_batch_trans_sale");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.BatchTransactions)
                .HasForeignKey(d => d.SaleOrderId)
                .HasConstraintName("fk_batch_trans_sale_order");

            entity.HasOne(d => d.SaleReturn).WithMany(p => p.BatchTransactions)
                .HasForeignKey(d => d.SaleReturnId)
                .HasConstraintName("fk_batch_trans_sale_return");

            entity.HasOne(d => d.SkuNavigation).WithMany(p => p.BatchTransactions)
                .HasForeignKey(d => d.Sku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_batch_trans_sku");
        });

        modelBuilder.Entity<Buy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_id");

            entity.ToTable("buy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyOrderId).HasColumnName("buy_order_id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc).HasColumnName("no_doc");
            entity.Property(e => e.Serie)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.SupplierCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("supplier_code");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("user_code");

            entity.HasOne(d => d.BuyOrder).WithMany(p => p.Buys)
                .HasForeignKey(d => d.BuyOrderId)
                .HasConstraintName("fk_buy_buy_order_id");

            entity.HasOne(d => d.Document).WithMany(p => p.Buys)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_document_id");

            entity.HasOne(d => d.SupplierCodeNavigation).WithMany(p => p.Buys)
                .HasForeignKey(d => d.SupplierCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_supplier_id");

            entity.HasOne(d => d.TransState).WithMany(p => p.Buys)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_state_id");

            entity.HasOne(d => d.UserCodeNavigation).WithMany(p => p.Buys)
                .HasForeignKey(d => d.UserCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_user_id");
        });

        modelBuilder.Entity<BuyDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_det");

            entity.ToTable("buy_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyId).HasColumnName("buy_id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("units");

            entity.HasOne(d => d.Buy).WithMany(p => p.BuyDets)
                .HasForeignKey(d => d.BuyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_det_buy_id");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.BuyDets)
                .HasForeignKey(d => d.CellarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_cellar_id");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.BuyDets)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_det_product");
        });

        modelBuilder.Entity<BuyOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_order");

            entity.ToTable("buy_order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc).HasColumnName("no_doc");
            entity.Property(e => e.OutputDocumentId).HasColumnName("output_document_id");
            entity.Property(e => e.Serie)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.SupplierCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("supplier_code");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("user_code");

            entity.HasOne(d => d.Document).WithMany(p => p.BuyOrderDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_document_id");

            entity.HasOne(d => d.OutputDocument).WithMany(p => p.BuyOrderOutputDocuments)
                .HasForeignKey(d => d.OutputDocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_output_document_id");

            entity.HasOne(d => d.SupplierCodeNavigation).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.SupplierCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_supplier_id");

            entity.HasOne(d => d.TransState).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_state_id");

            entity.HasOne(d => d.UserCodeNavigation).WithMany(p => p.BuyOrders)
                .HasForeignKey(d => d.UserCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_user_id");
        });

        modelBuilder.Entity<BuyOrderDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_order_det");

            entity.ToTable("buy_order_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyOrderId).HasColumnName("buy_order_id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("units");

            entity.HasOne(d => d.BuyOrder).WithMany(p => p.BuyOrderDets)
                .HasForeignKey(d => d.BuyOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_det_buy_order");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.BuyOrderDets)
                .HasForeignKey(d => d.CellarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_cellar_code");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.BuyOrderDets)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_order_det_product");
        });

        modelBuilder.Entity<BuyReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_return_id");

            entity.ToTable("buy_return");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc).HasColumnName("no_doc");
            entity.Property(e => e.Observation)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("observation");
            entity.Property(e => e.Serie)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serie");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.SupplierCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("supplier_code");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("user_code");

            entity.HasOne(d => d.Document).WithMany(p => p.BuyReturns)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_return_document");

            entity.HasOne(d => d.SupplierCodeNavigation).WithMany(p => p.BuyReturns)
                .HasForeignKey(d => d.SupplierCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_return_supplier");

            entity.HasOne(d => d.TransState).WithMany(p => p.BuyReturns)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_return_state");

            entity.HasOne(d => d.UserCodeNavigation).WithMany(p => p.BuyReturns)
                .HasForeignKey(d => d.UserCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_return_user");
        });

        modelBuilder.Entity<BuyReturnDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_buy_return_det");

            entity.ToTable("buy_return_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyId).HasColumnName("buy_id");
            entity.Property(e => e.BuyReturnId).HasColumnName("buy_return_id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("units");

            entity.HasOne(d => d.BuyReturn).WithMany(p => p.BuyReturnDets)
                .HasForeignKey(d => d.BuyReturnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_return_det_buy_return");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.BuyReturnDets)
                .HasForeignKey(d => d.CellarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_return_det_cellar");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.BuyReturnDets)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_buy_return_det_product");
        });

        modelBuilder.Entity<Cellar>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("pk_cellar");

            entity.ToTable("cellar");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("code");
            entity.Property(e => e.Address)
                .HasMaxLength(80)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CellarTransfer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cellar_transf_id");

            entity.ToTable("cellar_transfer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.NoDoc)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("no_doc");
            entity.Property(e => e.Observation)
                .HasMaxLength(350)
                .HasColumnName("observation");
            entity.Property(e => e.UserCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("user_code");

            entity.HasOne(d => d.Document).WithMany(p => p.CellarTransfers)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_transf_doc_id");

            entity.HasOne(d => d.UserCodeNavigation).WithMany(p => p.CellarTransfers)
                .HasForeignKey(d => d.UserCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_transf_user_code");
        });

        modelBuilder.Entity<CellarTransferDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cellar_trans_det_id");

            entity.ToTable("cellar_transfer_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarDestinationCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_destination_code");
            entity.Property(e => e.CellarOriginCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_origin_code");
            entity.Property(e => e.CellarTransId).HasColumnName("cellar_trans_id");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.CellarDestinationCodeNavigation).WithMany(p => p.CellarTransferDetCellarDestinationCodeNavigations)
                .HasForeignKey(d => d.CellarDestinationCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_trans_cellar_destination");

            entity.HasOne(d => d.CellarOriginCodeNavigation).WithMany(p => p.CellarTransferDetCellarOriginCodeNavigations)
                .HasForeignKey(d => d.CellarOriginCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_trans_cellar_origin");

            entity.HasOne(d => d.CellarTrans).WithMany(p => p.CellarTransferDets)
                .HasForeignKey(d => d.CellarTransId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_trans_id");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.CellarTransferDets)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cellar_trans_product");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("pk_customer_id");

            entity.ToTable("customer");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.CreditLimit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("credit_limit");
            entity.Property(e => e.Cui)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cui");
            entity.Property(e => e.Defaulter).HasColumnName("defaulter");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.Category).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_category");
        });

        modelBuilder.Entity<CustomerCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F921669B0");

            entity.ToTable("customer_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_document");

            entity.ToTable("document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.InternalCorrelative).HasColumnName("internal_correlative");
            entity.Property(e => e.Serie)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("serie");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("fk_document_doc_type");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__document__3213E83F51FB6782");

            entity.ToTable("document_type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_inventory");

            entity.ToTable("inventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("last_update");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CellarCode)
                .HasConstraintName("fk_inventory_cellar");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductSku)
                .HasConstraintName("fk_inventory_product");
        });

        modelBuilder.Entity<MinMaxProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_min_max_id");

            entity.ToTable("min_max_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.Maximum).HasColumnName("maximum");
            entity.Property(e => e.Minimum).HasColumnName("minimum");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.MinMaxProducts)
                .HasForeignKey(d => d.CellarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_min_max_cellar");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.MinMaxProducts)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_min_max_prod");
        });

        modelBuilder.Entity<PriceRoundSy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__price_ro__3213E83F12515F2A");

            entity.ToTable("price_round_sys");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Sku).HasName("pk_product");

            entity.ToTable("product", tb => tb.HasTrigger("trigger_insert_product"));

            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("sku");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BuyPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("buy_price");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.MeasureId).HasColumnName("measure_id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PriceList).HasColumnName("price_list");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("fk_product_brand");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_product_category");

            entity.HasOne(d => d.Measure).WithMany(p => p.Products)
                .HasForeignKey(d => d.MeasureId)
                .HasConstraintName("fk_product_measure");

            entity.HasOne(d => d.PriceListNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.PriceList)
                .HasConstraintName("fk_product_price_list");

            entity.HasOne(d => d.Status).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_product_status");
        });

        modelBuilder.Entity<ProductBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F1772138A");

            entity.ToTable("product_brand");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F8791A61F");

            entity.ToTable("product_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProductMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F46577906");

            entity.ToTable("product_measure");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProductPriceList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F63A6ABB4");

            entity.ToTable("product_price_list");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaseList).HasColumnName("base_list");
            entity.Property(e => e.Factor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("factor");
            entity.Property(e => e.ListName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("list_name");
            entity.Property(e => e.RoundSys).HasColumnName("round_sys");
        });

        modelBuilder.Entity<ProductState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F9633C68A");

            entity.ToTable("product_state");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .HasColumnName("description");
        });

        modelBuilder.Entity<RolUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rol_user__3213E83F06C3A09F");

            entity.ToTable("rol_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale");

            entity.ToTable("sale");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.CustomerCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("customer_code");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc).HasColumnName("no_doc");
            entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
            entity.Property(e => e.Serie)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("serie");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("user_code");

            entity.HasOne(d => d.CustomerCodeNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_customer");

            entity.HasOne(d => d.Document).WithMany(p => p.Sales)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_document");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SaleOrderId)
                .HasConstraintName("fk_sale_order_id");

            entity.HasOne(d => d.TransState).WithMany(p => p.Sales)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_state");

            entity.HasOne(d => d.UserCodeNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_user");
        });

        modelBuilder.Entity<SaleDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_det");

            entity.ToTable("sale_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("units");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.SaleDets)
                .HasForeignKey(d => d.CellarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_det_cellar");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.SaleDets)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_det_product");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDets)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_det_sale");
        });

        modelBuilder.Entity<SaleOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_order");

            entity.ToTable("sale_order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CreditDays).HasColumnName("credit_days");
            entity.Property(e => e.CustomerCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("customer_code");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc).HasColumnName("no_doc");
            entity.Property(e => e.OutputDocumentId).HasColumnName("output_document_id");
            entity.Property(e => e.Serie)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("serie");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("user_code");

            entity.HasOne(d => d.CustomerCodeNavigation).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.CustomerCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_customer");

            entity.HasOne(d => d.Document).WithMany(p => p.SaleOrderDocuments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_document");

            entity.HasOne(d => d.OutputDocument).WithMany(p => p.SaleOrderOutputDocuments)
                .HasForeignKey(d => d.OutputDocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_output_document");

            entity.HasOne(d => d.TransState).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_state");

            entity.HasOne(d => d.UserCodeNavigation).WithMany(p => p.SaleOrders)
                .HasForeignKey(d => d.UserCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_user");
        });

        modelBuilder.Entity<SaleOrderDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_order_det");

            entity.ToTable("sale_order_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("units");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.SaleOrderDets)
                .HasForeignKey(d => d.CellarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_det_cellar");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.SaleOrderDets)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_det_product");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.SaleOrderDets)
                .HasForeignKey(d => d.SaleOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_order_det_sale_order");
        });

        modelBuilder.Entity<SaleReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_return");

            entity.ToTable("sale_return");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CustomerCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("customer_code");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DateTrans)
                .HasColumnType("datetime")
                .HasColumnName("date_trans");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("iva");
            entity.Property(e => e.NoDoc).HasColumnName("no_doc");
            entity.Property(e => e.Observation)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("observation");
            entity.Property(e => e.Serie)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("serie");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TransStateId).HasColumnName("trans_state_id");
            entity.Property(e => e.UserCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("user_code");

            entity.HasOne(d => d.CustomerCodeNavigation).WithMany(p => p.SaleReturns)
                .HasForeignKey(d => d.CustomerCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_return_customer");

            entity.HasOne(d => d.Document).WithMany(p => p.SaleReturns)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_return_docuement");

            entity.HasOne(d => d.TransState).WithMany(p => p.SaleReturns)
                .HasForeignKey(d => d.TransStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_return_state");

            entity.HasOne(d => d.UserCodeNavigation).WithMany(p => p.SaleReturns)
                .HasForeignKey(d => d.UserCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_return_user");
        });

        modelBuilder.Entity<SaleReturnDet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sale_return_det");

            entity.ToTable("sale_return_det");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleReturnId).HasColumnName("sale_return_id");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sub_total");
            entity.Property(e => e.Units)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("units");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.SaleReturnDets)
                .HasForeignKey(d => d.CellarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_return_cellar");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.SaleReturnDets)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_return_product");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleReturnDets)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_return_det_sale");

            entity.HasOne(d => d.SaleReturn).WithMany(p => p.SaleReturnDets)
                .HasForeignKey(d => d.SaleReturnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_return_det_sale_return");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("pk_supplier");

            entity.ToTable("supplier");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.Category).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supplier_category");
        });

        modelBuilder.Entity<SupplierCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__3213E83F1E90D5EF");

            entity.ToTable("supplier_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_transaction_detail");

            entity.ToTable("transaction_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyId).HasColumnName("buy_id");
            entity.Property(e => e.BuyReturnId).HasColumnName("buy_return_id");
            entity.Property(e => e.CellarCode)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("cellar_code");
            entity.Property(e => e.CellarTransferId).HasColumnName("cellar_transfer_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.NoDoc)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("no_doc");
            entity.Property(e => e.ProductSku)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_sku");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.SaleReturnId).HasColumnName("sale_return_id");
            entity.Property(e => e.Units)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("units");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("value");

            entity.HasOne(d => d.Buy).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.BuyId)
                .HasConstraintName("fk_transaction_detail_buy");

            entity.HasOne(d => d.BuyReturn).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.BuyReturnId)
                .HasConstraintName("fk_transaction_detail_buy_return");

            entity.HasOne(d => d.CellarCodeNavigation).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.CellarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transaction_detail_cellar");

            entity.HasOne(d => d.CellarTransfer).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.CellarTransferId)
                .HasConstraintName("fk_transaction_detail_cellar_trans");

            entity.HasOne(d => d.ProductSkuNavigation).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.ProductSku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_transaction_detail_product");

            entity.HasOne(d => d.Sale).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("fk_transaction_detail_sale");

            entity.HasOne(d => d.SaleReturn).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.SaleReturnId)
                .HasConstraintName("fk_transaction_detail_sale_return");
        });

        modelBuilder.Entity<TransactionState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transact__3213E83F110E85CF");

            entity.ToTable("transaction_state");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<UserSy>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("pk_user_sys");

            entity.ToTable("user_sys");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("code");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .HasColumnName("password");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Rol).WithMany(p => p.UserSies)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("fk_user_sys_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
