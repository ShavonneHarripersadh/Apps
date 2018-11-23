using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Punters.Migrations
{
    public partial class CreatePunter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetDetails",
                columns: table => new
                {
                    BetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PunterID = table.Column<int>(nullable: false),
                    PunterName = table.Column<string>(nullable: true),
                    MarketID = table.Column<int>(nullable: false),
                    MarketName = table.Column<string>(nullable: true),
                    Odds = table.Column<decimal>(nullable: false),
                    Stake = table.Column<decimal>(nullable: false),
                    PotentialPayout = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetDetails", x => x.BetID);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    MarketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarketName = table.Column<string>(maxLength: 25, nullable: false),
                    Odds = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.MarketID);
                });

            migrationBuilder.CreateTable(
                name: "Punter",
                columns: table => new
                {
                    PunterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PunterName = table.Column<string>(maxLength: 25, nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punter", x => x.PunterID);
                });

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    BetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarketID = table.Column<int>(nullable: false),
                    PunterID = table.Column<int>(nullable: false),
                    Odds = table.Column<decimal>(nullable: false),
                    Stake = table.Column<decimal>(nullable: false),
                    PotentialPayout = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.BetID);
                    table.ForeignKey(
                        name: "FK_Bet_Market_MarketID",
                        column: x => x.MarketID,
                        principalTable: "Market",
                        principalColumn: "MarketID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bet_Punter_PunterID",
                        column: x => x.PunterID,
                        principalTable: "Punter",
                        principalColumn: "PunterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_MarketID",
                table: "Bet",
                column: "MarketID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_PunterID",
                table: "Bet",
                column: "PunterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropTable(
                name: "BetDetails");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Punter");
        }
    }
}
