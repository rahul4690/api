using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class migration_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_otpModels",
                table: "otpModels");

            migrationBuilder.RenameTable(
                name: "otpModels",
                newName: "OtpModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtpModels",
                table: "OtpModels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OtpModels",
                table: "OtpModels");

            migrationBuilder.RenameTable(
                name: "OtpModels",
                newName: "otpModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_otpModels",
                table: "otpModels",
                column: "Id");
        }
    }
}
