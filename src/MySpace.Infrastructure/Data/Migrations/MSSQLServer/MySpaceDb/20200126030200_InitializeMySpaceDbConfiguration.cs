using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySpace.Infrastructure.Data.Migrations.MSSQLServer.MySpaceDb
{
    public partial class InitializeMySpaceDbConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentPasswordHash = table.Column<string>(nullable: false),
                    LastPasswordHash = table.Column<string>(nullable: true),
                    ExpiredTime = table.Column<DateTimeOffset>(nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(nullable: false),
                    ModifyTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPasswords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Remark = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordId = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(nullable: false),
                    ModifyTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apps_AppPasswords_PasswordId",
                        column: x => x.PasswordId,
                        principalTable: "AppPasswords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apps_PasswordId",
                table: "Apps",
                column: "PasswordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "AppPasswords");
        }
    }
}
