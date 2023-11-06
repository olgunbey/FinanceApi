using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceInfrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAdi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountMoneyTransferLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendIBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetIBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountMoneyTransferLog", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountMoneyTransferLog");
        }
    }
}
