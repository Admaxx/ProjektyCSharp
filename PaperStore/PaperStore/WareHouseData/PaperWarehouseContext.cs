﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PaperStore.WareHouseData;

public partial class PaperWarehouseContext : DbContext
{
    public PaperWarehouseContext()
    {
    }

    public PaperWarehouseContext(DbContextOptions<PaperWarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CurrentStock> CurrentStocks { get; set; }

    public virtual DbSet<StockAdditionalInfo> StockAdditionalInfos { get; set; }

    public virtual DbSet<StockItem> StockItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VTOS691\\MSSQLSERVER01;database=PaperWarehouse;user=sa;password=Jajeczko8;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrentStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__current___3214EC07C15014C7");

            entity.ToTable("current_stock", tb =>
                {
                    tb.HasTrigger("set_input_date");
                    tb.HasTrigger("set_update_date");
                });

            entity.Property(e => e.AddtionalInfoId).HasColumnName("addtional_info_Id");
            entity.Property(e => e.Archive).HasColumnName("archive");
            entity.Property(e => e.InputData)
                .HasColumnType("datetime")
                .HasColumnName("input_data");
            entity.Property(e => e.ProductName).HasColumnName("product_name");
            entity.Property(e => e.UpdateData)
                .HasColumnType("datetime")
                .HasColumnName("update_data");
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

            entity.Property(e => e.ItemName)
                .IsUnicode(false)
                .HasColumnName("item_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
