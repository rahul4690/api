using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class migration_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_category",
                table: "tbl_category");

            migrationBuilder.DropColumn(
                name: "id",
                table: "tbl_category");

            migrationBuilder.DropColumn(
                name: "categosryName",
                table: "tbl_category");

            migrationBuilder.AddColumn<string>(
                name: "categoryCode",
                table: "tbl_category",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "categoryName",
                table: "tbl_category",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "tbl_category",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryCode",
                table: "tbl_category");

            migrationBuilder.DropColumn(
                name: "categoryName",
                table: "tbl_category");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "tbl_category");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "tbl_category",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "categosryName",
                table: "tbl_category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_category",
                table: "tbl_category",
                column: "id");
        }
    }
}
