using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttentionPlease.EFCore.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarSubscribers_Calendars_CalendarId",
                table: "CalendarSubscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarSubscribers_Calendars_CalendarId1",
                table: "CalendarSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarSubscribers",
                table: "CalendarSubscribers");

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("5381b378-34c8-459d-bea1-edee564ae727"));

            migrationBuilder.RenameTable(
                name: "CalendarSubscribers",
                newName: "CalendarSubscriptions");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarSubscribers_CalendarId1",
                table: "CalendarSubscriptions",
                newName: "IX_CalendarSubscriptions_CalendarId1");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarSubscribers_CalendarId",
                table: "CalendarSubscriptions",
                newName: "IX_CalendarSubscriptions_CalendarId");

            migrationBuilder.AddColumn<Guid>(
                name: "CalendarId",
                table: "AnniversaryCelebrations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarSubscriptions",
                table: "CalendarSubscriptions",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("169c2d8d-4db8-45f6-9278-30890a3e8bc3"), "Fam Jerndin" });

            migrationBuilder.CreateIndex(
                name: "IX_AnniversaryCelebrations_CalendarId",
                table: "AnniversaryCelebrations",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnniversaryCelebrations_Calendars_CalendarId",
                table: "AnniversaryCelebrations",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarSubscriptions_Calendars_CalendarId",
                table: "CalendarSubscriptions",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarSubscriptions_Calendars_CalendarId1",
                table: "CalendarSubscriptions",
                column: "CalendarId1",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnniversaryCelebrations_Calendars_CalendarId",
                table: "AnniversaryCelebrations");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarSubscriptions_Calendars_CalendarId",
                table: "CalendarSubscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarSubscriptions_Calendars_CalendarId1",
                table: "CalendarSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_AnniversaryCelebrations_CalendarId",
                table: "AnniversaryCelebrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarSubscriptions",
                table: "CalendarSubscriptions");

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("169c2d8d-4db8-45f6-9278-30890a3e8bc3"));

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "AnniversaryCelebrations");

            migrationBuilder.RenameTable(
                name: "CalendarSubscriptions",
                newName: "CalendarSubscribers");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarSubscriptions_CalendarId1",
                table: "CalendarSubscribers",
                newName: "IX_CalendarSubscribers_CalendarId1");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarSubscriptions_CalendarId",
                table: "CalendarSubscribers",
                newName: "IX_CalendarSubscribers_CalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarSubscribers",
                table: "CalendarSubscribers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5381b378-34c8-459d-bea1-edee564ae727"), "Fam Jerndin" });

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
    }
}
