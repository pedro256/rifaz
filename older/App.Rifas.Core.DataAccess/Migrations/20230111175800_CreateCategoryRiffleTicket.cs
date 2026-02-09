using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Rifas.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateCategoryRAFFLETicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "RAFFLE_CATEGORY",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false, name: "ID")
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   CreatedDate = table.Column<DateTime>(nullable: false, name: "CREATED_AT"),
                   UpdatedDate = table.Column<DateTime>(nullable: false, name: "UPDATED_AT"),
                   Name = table.Column<string>(nullable: false, name: "NAME"),
                   Description = table.Column<string>(nullable:true,name:"DESCRIPTION")
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_RAFFLE_CATEGORY", x => x.Id);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("RAFFLE_CATEGORY");
        }
    }
}
