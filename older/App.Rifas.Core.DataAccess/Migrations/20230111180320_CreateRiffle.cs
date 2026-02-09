using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Rifas.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateRAFFLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "RAFFLE",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false, name: "ID")
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   CreatedDate = table.Column<DateTime>(nullable: false, name: "CREATED_AT"),
                   UpdatedDate = table.Column<DateTime>(nullable: false, name: "UPDATED_AT"),
                   Name = table.Column<string>(nullable: false, name: "NAME"),
                   Description = table.Column<string>(nullable: true, name: "DESCRIPTION"),
                   Protocol = table.Column<string>(nullable: false, name: "PROTOCOL"),
                   OwnerId = table.Column<int>(nullable:false, name:"OWNER_ID"),
                   CategoryId = table.Column<int>(nullable:false,name:"CATEGORY_ID")
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_RAFFLE", x => x.Id);
                   table.ForeignKey(
                       "FK_OWNER_ID", 
                       x => x.OwnerId, 
                       "USERS", 
                       "ID", 
                       null, 
                       ReferentialAction.NoAction,
                       ReferentialAction.SetNull);
                   table.ForeignKey(
                       "FK_CATEGORY_ID",
                       x => x.CategoryId,
                       "RAFFLE_CATEGORY",
                       "ID",
                       null,
                       ReferentialAction.NoAction,
                       ReferentialAction.SetNull);

               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_OWNER_ID", "RAFFLE");
            migrationBuilder.DropForeignKey("FK_CATEGORY_ID", "RAFFLE");
            migrationBuilder.DropTable("RAFFLE");
        }
    }
}
