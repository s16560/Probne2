using Microsoft.EntityFrameworkCore.Migrations;

namespace Probne2.Migrations
{
    public partial class Seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MusicLabels",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 1, "Sony" });

            migrationBuilder.InsertData(
                table: "MusicLabels",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[] { 2, "Dux" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MusicLabels",
                keyColumn: "IdMusicLabel",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MusicLabels",
                keyColumn: "IdMusicLabel",
                keyValue: 2);
        }
    }
}
