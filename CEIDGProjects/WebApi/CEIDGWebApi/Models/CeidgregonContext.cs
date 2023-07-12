using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CEIDGWebApi.Models;

public partial class CeidgregonContext : DbContext
{
    public CeidgregonContext()
    {
    }

    public CeidgregonContext(DbContextOptions<CeidgregonContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<Gusvalue> Gusvalues { get; set; }

    IConfiguration JsonData { get; init; } = new ConfigurationBuilder().AddJsonFile("connection.json").Build(); //Getting server navigation from appsettings.json

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(JsonData["ConnectionStrings:CEIDGConn"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gusvalue>(entity =>
        {
            entity
                .ToTable("GUSValues");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ImportDate).HasColumnType("datetime");
            entity.Property(e => e.Xmlvalues)
                .IsUnicode(false)
                .HasColumnName("XMLValues");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
