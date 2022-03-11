using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank.Infrastructure.Migrations
{
    public partial class Added_currencytype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyType",
                table: "BankOperations",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyType",
                table: "BankOperations");
        }
    }
}
