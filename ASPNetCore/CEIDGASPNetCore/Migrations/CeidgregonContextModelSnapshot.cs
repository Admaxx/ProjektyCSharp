﻿// <auto-generated />
using System;
using CEIDGASPNetCore.DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CEIDGASPNetCore.Migrations
{
    [DbContext(typeof(CeidgregonContext))]
    partial class CeidgregonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CEIDGASPNetCore.DbModel.Gusvalue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("ImportDate")
                        .HasColumnType("date");

                    b.Property<byte>("RaportType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Xmlvalues")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("XMLValues");

                    b.HasKey("Id");

                    b.ToTable("GUSValues", (string)null);
                });

            modelBuilder.Entity("CEIDGASPNetCore.DbModel.RaportTypeNames", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("RaportType")
                        .HasColumnType("int");

                    b.Property<string>("RaportTypeName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("RaportTypeName");

                    b.HasKey("Id");

                    b.ToTable("RaportTypeNames", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
