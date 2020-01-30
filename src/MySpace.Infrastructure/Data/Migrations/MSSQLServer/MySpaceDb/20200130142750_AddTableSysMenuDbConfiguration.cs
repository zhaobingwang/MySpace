using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySpace.Infrastructure.Data.Migrations.MSSQLServer.MySpaceDb
{
    public partial class AddTableSysMenuDbConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 16, nullable: false),
                    Remark = table.Column<string>(maxLength: 256, nullable: true),
                    ParentId = table.Column<int>(nullable: false, defaultValue: 0),
                    IsShow = table.Column<short>(nullable: false, defaultValue: (short)0),
                    Url = table.Column<string>(maxLength: 1024, nullable: true),
                    Icon = table.Column<string>(maxLength: 64, nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(nullable: false),
                    ModifyTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysMenus");
        }
    }
}
