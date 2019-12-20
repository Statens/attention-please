using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttentionPlease.EFCore.Migrations
{
    public partial class InitialCommit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("e79fc143-bd39-4b58-9a4e-41c4fa480320"));

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5381b378-34c8-459d-bea1-edee564ae727"), "Fam Jerndin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("5381b378-34c8-459d-bea1-edee564ae727"));

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e79fc143-bd39-4b58-9a4e-41c4fa480320"), "Fam Jer" });
        }
    }
}
