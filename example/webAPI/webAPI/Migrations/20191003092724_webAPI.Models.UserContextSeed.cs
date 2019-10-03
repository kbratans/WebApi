using Microsoft.EntityFrameworkCore.Migrations;

namespace webAPI.Migrations
{
    public partial class webAPIModelsUserContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "IsDeleted", "Name", "Surname", "UserName" },
                values: new object[] { 1, false, "Uncle", "Bob", "Bobun" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "IsDeleted", "Name", "Surname", "UserName" },
                values: new object[] { 2, false, "Jan", "Kirsten", "Janki" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
