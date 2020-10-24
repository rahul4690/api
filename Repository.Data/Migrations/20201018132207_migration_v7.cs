using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class migration_v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OtpModels",
                table: "OtpModels");

            migrationBuilder.AlterColumn<string>(
                name: "otp",
                table: "OtpModels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OtpModels",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OtpModels");

            migrationBuilder.AlterColumn<string>(
                name: "otp",
                table: "OtpModels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtpModels",
                table: "OtpModels",
                column: "otp");
        }
    }
}
