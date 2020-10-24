using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class migration_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtpModels",
                table: "OtpModels",
                column: "otp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OtpModels",
                table: "OtpModels");

            migrationBuilder.AlterColumn<string>(
                name: "otp",
                table: "OtpModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OtpModels",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtpModels",
                table: "OtpModels",
                column: "Id");
        }
    }
}
