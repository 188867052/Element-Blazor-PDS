using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.ServerRender.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Issues",
              columns: table => new
              {
                  Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  Status = table.Column<int>(type: "int", nullable: false),
                  CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                  UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Issues", x => x.Id);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Issues");

           
        }
    }
}
