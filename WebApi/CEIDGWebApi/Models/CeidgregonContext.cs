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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VTOS691\\MSSQLSERVER01;database=CEIDGREGON;User ID = sa;Password = Jajeczko8;Encrypt=True;TrustServerCertificate=True;");

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
