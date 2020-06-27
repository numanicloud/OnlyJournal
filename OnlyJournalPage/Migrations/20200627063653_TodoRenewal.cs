using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlyJournalPage.Migrations
{
    public partial class TodoRenewal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginTime",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "IsFinishByEndTime",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Todo");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Todo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PriorTimeBegin",
                table: "Todo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PriorTimeEnd",
                table: "Todo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "PriorTimeBegin",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "PriorTimeEnd",
                table: "Todo");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginTime",
                table: "Todo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Todo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinishByEndTime",
                table: "Todo",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Todo",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
