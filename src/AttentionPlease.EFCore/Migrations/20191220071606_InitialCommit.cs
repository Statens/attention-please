using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttentionPlease.EFCore.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("0d52edcc-09ac-4f5b-8d5d-c00c8c326290"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CalendarId",
                table: "CalendarSubscribers",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CalendarId1",
                table: "CalendarSubscribers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e79fc143-bd39-4b58-9a4e-41c4fa480320"), "Fam Jer" });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarSubscribers_CalendarId",
                table: "CalendarSubscribers",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarSubscribers_CalendarId1",
                table: "CalendarSubscribers",
                column: "CalendarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarSubscribers_Calendars_CalendarId",
                table: "CalendarSubscribers",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarSubscribers_Calendars_CalendarId1",
                table: "CalendarSubscribers",
                column: "CalendarId1",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarSubscribers_Calendars_CalendarId",
                table: "CalendarSubscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarSubscribers_Calendars_CalendarId1",
                table: "CalendarSubscribers");

            migrationBuilder.DropIndex(
                name: "IX_CalendarSubscribers_CalendarId",
                table: "CalendarSubscribers");

            migrationBuilder.DropIndex(
                name: "IX_CalendarSubscribers_CalendarId1",
                table: "CalendarSubscribers");

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("e79fc143-bd39-4b58-9a4e-41c4fa480320"));

            migrationBuilder.DropColumn(
                name: "CalendarId1",
                table: "CalendarSubscribers");

            migrationBuilder.AlterColumn<Guid>(
                name: "CalendarId",
                table: "CalendarSubscribers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0d52edcc-09ac-4f5b-8d5d-c00c8c326290"), "Fam Jer" });
        }
    }
}
