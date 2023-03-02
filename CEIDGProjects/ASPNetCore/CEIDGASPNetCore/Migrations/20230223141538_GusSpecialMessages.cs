using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEIDGASPNetCore.Migrations
{
    /// <inheritdoc />
    public partial class GusSpecialMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GusSpecialMessages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GusSpecialMessageValue = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    GusSpecialMessageText = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GusSpecialMessages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GusSpecialMessages");
        }
    }
}
