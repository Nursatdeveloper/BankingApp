using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Infrastructure.Migrations
{
    public partial class From_To_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromAccount",
                table: "BankOperations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToAccount",
                table: "BankOperations",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromAccount",
                table: "BankOperations");

            migrationBuilder.DropColumn(
                name: "ToAccount",
                table: "BankOperations");
        }
    }
}
