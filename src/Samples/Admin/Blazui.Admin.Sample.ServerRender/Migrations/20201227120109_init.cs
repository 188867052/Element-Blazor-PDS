using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.ServerRender.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                   name: "Meetings",
                   columns: table => new
                   {
                       Id = table.Column<int>(type: "int", nullable: false)
                           .Annotation("SqlServer:Identity", "1, 1"),
                       Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                       Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                       CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                       UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                   },
                   constraints: table =>
                   {
                       table.PrimaryKey("PK_Meetings", x => x.Id);
                   });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RoleResources");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
