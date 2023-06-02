namespace PaperStore.PaperStoreModel;

public partial class PaperWarehouseContext : DbContext
{
    public PaperWarehouseContext()
    {
    }

    public PaperWarehouseContext(DbContextOptions<PaperWarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompaniesList> CompaniesLists { get; set; }

    public virtual DbSet<CurrentStock> CurrentStocks { get; set; }

    public virtual DbSet<LoginOption> LoginOptions { get; set; }

    public virtual DbSet<StockAdditionalInfo> StockAdditionalInfos { get; set; }

    public virtual DbSet<StockItem> StockItems { get; set; }

    IConfiguration jsonData = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); //Getting server navigation from appsettings.json
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            $"{jsonData["ConnectionStrings:Server"]}" +
            $"{jsonData["ConnectionStrings:database"]}" +
            $"{jsonData["ConnectionStrings:user"]}" +
            $"{jsonData["ConnectionStrings:password"]}" +
            $"{jsonData["ConnectionStrings:trustservercertificate"]}" 
            );
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompaniesList>(entity =>
        {
            entity.ToTable("companiesList");

            entity.Property(e => e.CompanyName)
                .IsUnicode(false)
                .HasColumnName("company_name");
        });

        modelBuilder.Entity<CurrentStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__current___3214EC07C15014C7");

            entity.ToTable("current_stock", tb => tb.HasTrigger("SetBasicsDataToNewItems"));

            entity.Property(e => e.AddtionalInfoId).HasColumnName("addtional_info_Id");
            entity.Property(e => e.Archive).HasColumnName("archive");
            entity.Property(e => e.InputData)
                .HasColumnType("datetime")
                .HasColumnName("input_data");
            entity.Property(e => e.ProductName).HasColumnName("product_name");
            entity.Property(e => e.UpdateData)
                .HasColumnType("datetime")
                .HasColumnName("update_data");

            entity.HasOne(d => d.AddtionalInfoNavigation).WithMany(p => p.CurrentStocks)
                .HasForeignKey(d => d.AddtionalInfoId)
                .HasConstraintName("FK_current_stock_stock_additional_info");

            entity.HasOne(d => d.ProductNameNavigation).WithMany(p => p.CurrentStocks)
                .HasForeignKey(d => d.ProductName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_current_stock_stock_items");
        });

        modelBuilder.Entity<LoginOption>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("SetCreatedDateToNewAccount"));
        });

        modelBuilder.Entity<StockAdditionalInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__stock_ad__3214EC070CAB2132");

            entity.ToTable("stock_additional_info");

            entity.Property(e => e.AdditionalInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("additional_info");
        });

        modelBuilder.Entity<StockItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__stock_it__3214EC07E3A7402F");

            entity.ToTable("stock_items");

            entity.Property(e => e.CompanyId).HasColumnName("company_Id");
            entity.Property(e => e.ItemName)
                .IsUnicode(false)
                .HasColumnName("item_name");

            entity.HasOne(d => d.Company).WithMany(p => p.StockItems)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_stock_items_companiesList");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
//new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["ConnectionStrings:PaperStoreConn"] //Getting server navigation from appsettings.json