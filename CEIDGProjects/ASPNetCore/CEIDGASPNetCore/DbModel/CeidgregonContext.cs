﻿using System;
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
    public virtual DbSet<RaportTypeNames> RaportTypeNames { get; set; }
    public virtual DbSet<GusSpecialMessages> GusSpecialMessages { get; set; }
    public virtual DbSet<RaportyNamesModel> RaportyNames { get; set; }

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
        modelBuilder.Entity<GusSpecialMessages>(entity =>
        {
            entity
                .ToTable("GusSpecialMessages");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.GusSpecialMessageText)
                .IsUnicode(false)
                .HasColumnName("GusSpecialMessageText");
            entity.Property(e => e.GusSpecialMessageValue)
                .IsUnicode(false)
                .HasColumnName("GusSpecialMessageValue");
        });

        modelBuilder.Entity<RaportyNamesModel>(entity =>
        {
            entity
                .ToTable("WinRaporty");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NazwaRaportu)
                .IsUnicode(false)
                .HasColumnName("NazwaRaportu");
            entity.Property(e => e.Opis)
                .IsUnicode(false)
                .HasColumnName("Opis");
            entity.Property(e => e.NazwaSkrocona)
                .IsUnicode(false)
                .HasColumnName("NazwaSkrocona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
