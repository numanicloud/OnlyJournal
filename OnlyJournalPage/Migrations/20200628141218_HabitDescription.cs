using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlyJournalPage.Migrations
{
    public partial class HabitDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Habits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Habits");
        }
    }
}
