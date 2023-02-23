using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEIDGASPNetCore.DbModel;

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

    string ConnString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["ConnectionStrings:CEIDGConn"];
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(ConnString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gusvalue>(entity =>
        {
            entity
                .ToTable("GUSValues");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ImportDate).HasColumnType("date");
            entity.Property(e => e.Xmlvalues)
                .IsUnicode(false)
                .HasColumnName("XMLValues");
        });
        modelBuilder.Entity<RaportTypeNames>(entity =>
        {
            entity
                .ToTable("RaportTypeNames");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.RaportTypeName)
                .IsUnicode(false)
                .HasColumnName("RaportTypeName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
