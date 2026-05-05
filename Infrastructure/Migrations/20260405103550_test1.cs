using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecomerce.infrsutractor.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catogries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catogries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "proudcts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Describition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qualty = table.Column<int>(type: "int", nullable: false),
                    CatogryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proudcts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proudcts_catogries_CatogryId",
                        column: x => x.CatogryId,
                        principalTable: "catogries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_proudcts_CatogryId",
                table: "proudcts",
                column: "CatogryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proudcts");

            migrationBuilder.DropTable(
                name: "catogries");
        }
    }
}
