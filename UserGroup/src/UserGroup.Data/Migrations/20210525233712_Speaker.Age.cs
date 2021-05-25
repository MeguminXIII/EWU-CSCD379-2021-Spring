using Microsoft.EntityFrameworkCore.Migrations;

namespace UserGroup.Data.Migrations
{
    public partial class SpeakerAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Speaker",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Speaker");
        }
    }
}
