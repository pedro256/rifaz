using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Rifas.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRAFFLETickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "RAFFLE_TICKETS",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false, name: "ID")
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  CreatedDate = table.Column<DateTime>(nullable: false, name: "CREATED_AT"),
                  UpdatedDate = table.Column<DateTime>(nullable: false, name: "UPDATED_AT"),
                  NumTicket = table.Column<string>(nullable: false, name: "NUM_TICKER"),
                  UserId = table.Column<int>(nullable: false, name: "USER_ID"),
                  RaffleId = table.Column<int>(nullable: false, name: "RAFFLE_ID")
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_RAFFLE_TICKETS", x => x.Id);
                  table.ForeignKey(
                      "FK_USER_ID",
                      x => x.UserId,
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
            migrationBuilder.DropTable("RAFFLE_TICKETS");
        }
    }
}
