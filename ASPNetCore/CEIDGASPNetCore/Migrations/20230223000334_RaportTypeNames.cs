using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEIDGASPNetCore.Migrations
{
    /// <inheritdoc />
    public partial class RaportTypeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GUSValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XMLValues = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ImportDate = table.Column<DateTime>(type: "date", nullable: true),
                    RaportType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GUSValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaportTypeNames",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaportType = table.Column<int>(type: "int", nullable: false),
                    RaportTypeName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaportTypeNames", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GUSValues");

            migrationBuilder.DropTable(
                name: "RaportTypeNames");
        }
    }
}
