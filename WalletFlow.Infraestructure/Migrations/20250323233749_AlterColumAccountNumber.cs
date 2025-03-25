using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletFlow.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumAccountNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "accountNumber",
                table: "Wallets",
                newName: "AccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Wallets",
                newName: "accountNumber");
        }
    }
}
