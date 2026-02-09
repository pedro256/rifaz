using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Rifas.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "USERS",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false, name: "ID")
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   CreatedDate = table.Column<DateTime>(nullable: false,name:"CREATED_AT"),
                   UpdatedDate = table.Column<DateTime>(nullable: false,name:"UPDATED_AT"),
                   Name = table.Column<string>(nullable: false,name:"NAME"),
                   Email = table.Column<string>(nullable: false,name:"EMAIL"),
                   Password = table.Column<string>(nullable: false,name:"PASSWORD"),
                   BirthDate = table.Column<DateTime>(nullable: false,name:"BIRTH_DATE")
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_USER", x => x.Id);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("USERS");
        }
    }
}
