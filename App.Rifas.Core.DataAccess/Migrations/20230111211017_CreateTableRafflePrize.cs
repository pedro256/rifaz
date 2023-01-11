using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Rifas.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRAFFLEPrize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "RAFFLE_PRIZERS",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false, name: "ID")
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  CreatedDate = table.Column<DateTime>(nullable: false, name: "CREATED_AT"),
                  UpdatedDate = table.Column<DateTime>(nullable: false, name: "UPDATED_AT"),
                  Name = table.Column<string>(nullable: false, name: "NAME"),
                  Description = table.Column<string>(nullable: true, name: "DESCRIPTION"),
                  Position = table.Column<string>(nullable: true, name: "POSITION"),
                  WinnerId = table.Column<int>(nullable: true, name: "WINNER_ID"),
                  RaffleId = table.Column<int>(nullable: false, name: "RAFFLE_ID")
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_RAFFLE_PRIZERS", x => x.Id);
                  table.ForeignKey(
                      "FK_WINNER_ID",
                      x => x.WinnerId,
                      "USERS",
                      "ID",
                      null,
                      ReferentialAction.NoAction,
                      ReferentialAction.SetNull);
                  table.ForeignKey(
                      "FK_RAFFLE_ID",
                      x => x.RaffleId,
                      "RAFFLE",
                      "ID",
                      null,
                      ReferentialAction.NoAction,
                      ReferentialAction.SetNull);

              });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_WINNER_ID", "RAFFLE_PRIZERS");
            migrationBuilder.DropForeignKey("FK_RAFFLE_ID", "RAFFLE_PRIZERS");
            migrationBuilder.DropTable("RAFFLE_PRIZERS");
        }
    }
}
