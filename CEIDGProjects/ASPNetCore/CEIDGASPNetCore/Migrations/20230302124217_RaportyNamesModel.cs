using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEIDGASPNetCore.Migrations
{
    /// <inheritdoc />
    public partial class RaportyNamesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "RaportType",
                table: "RaportTypeNames",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "WinRaporty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaRaportu = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Opis = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    NazwaSkrocona = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    typRaportu = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinRaporty", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WinRaporty");

            migrationBuilder.AlterColumn<int>(
                name: "RaportType",
                table: "RaportTypeNames",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
