using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class migration_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tbl_application_users",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "mobile",
                table: "tbl_application_users",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "tbl_application_users",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "tbl_application_users",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aboutMe",
                table: "tbl_application_users",
                maxLength: 50,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "tbl_application_users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "tbl_application_users",
                maxLength: 50,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "tbl_application_users",
                maxLength: 50,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "tbl_application_users",
                maxLength: 50,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pincode",
                table: "tbl_application_users",
                maxLength: 50,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "tbl_application_users",
                maxLength: 50,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "tbl_application_users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aboutMe",
                table: "tbl_application_users");

            migrationBuilder.DropColumn(
                name: "address",
                table: "tbl_application_users");

            migrationBuilder.DropColumn(
                name: "city",
                table: "tbl_application_users");

            migrationBuilder.DropColumn(
                name: "country",
                table: "tbl_application_users");

            migrationBuilder.DropColumn(
                name: "image",
                table: "tbl_application_users");

            migrationBuilder.DropColumn(
                name: "pincode",
                table: "tbl_application_users");

            migrationBuilder.DropColumn(
                name: "state",
                table: "tbl_application_users");

            migrationBuilder.DropColumn(
                name: "username",
                table: "tbl_application_users");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tbl_application_users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "mobile",
                table: "tbl_application_users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "tbl_application_users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "tbl_application_users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldDefaultValue: "");
        }
    }
}
