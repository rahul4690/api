using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Data.Migrations
{
    public partial class migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserRoles",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    roleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
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
                    table.PrimaryKey("PK_ApplicationUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_ApplicationUserRoles_roleId",
                        column: x => x.roleId,
                        principalTable: "ApplicationUserRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_roleId",
                table: "ApplicationUsers",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "ApplicationUserRoles");
        }
    }
}
