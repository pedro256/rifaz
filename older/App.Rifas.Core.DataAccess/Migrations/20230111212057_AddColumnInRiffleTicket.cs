using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Rifas.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnInRAFFLETicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "NUM_START_COUNT",
                table: "RAFFLE",
                schema: null,
                nullable: false,
                defaultValue: 1
                );

            migrationBuilder.AddColumn<int>(
                name: "NUM_TICKETS",
                table: "RAFFLE",
                schema: null,
                nullable: false,
                defaultValue: 1
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("NUM_TICKETS", "RAFFLE");
            migrationBuilder.DropColumn("NUM_START_COUNT", "RAFFLE");
        }
    }
}
