using worldWideDbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace worldWideModels.contexts;

public partial class WorldWideDbContext : DbContext
{
    IConfiguration JsonData { get; init; } = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    public WorldWideDbContext()
    {
    }

    public WorldWideDbContext(DbContextOptions<WorldWideDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(JsonData["Connection:dbString"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("city");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Population).HasColumnName("population");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Country);

            entity.ToTable("region");

            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
