using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.CreateTable(
                name: "product",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    SellingPrice = table.Column<double>(type: "numeric(10,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "measure",
                schema: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<short>(type: "smallint", nullable: false),
                    Width = table.Column<short>(type: "smallint", nullable: false),
                    Depth = table.Column<short>(type: "smallint", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_measure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_measure_product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "product",
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_measure_ProductId",
                schema: "product",
                table: "measure",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "measure",
                schema: "product");

            migrationBuilder.DropTable(
                name: "product",
                schema: "product");
        }
    }
}
