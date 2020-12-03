using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_application_users_role",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    roleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_application_users_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_category",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    categosryName = table.Column<string>(nullable: true),
                    categoryImage = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_otp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    otp = table.Column<string>(nullable: true),
                    userId = table.Column<Guid>(nullable: false),
                    createdOn = table.Column<DateTime>(nullable: false),
                    isVerified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_otp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_application_users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    mobile = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    roleId = table.Column<Guid>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    lastLogin = table.Column<DateTime>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    updatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_application_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_application_users_tbl_application_users_role_roleId",
                        column: x => x.roleId,
                        principalTable: "tbl_application_users_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_application_users_roleId",
                table: "tbl_application_users",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_application_users");

            migrationBuilder.DropTable(
                name: "tbl_category");

            migrationBuilder.DropTable(
                name: "tbl_otp");

            migrationBuilder.DropTable(
                name: "tbl_application_users_role");
        }
    }
}
