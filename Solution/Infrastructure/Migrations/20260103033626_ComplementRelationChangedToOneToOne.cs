using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ComplementRelationChangedToOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_complement_CustomerId",
                schema: "customer",
                table: "complement");

            migrationBuilder.CreateIndex(
                name: "IX_complement_CustomerId",
                schema: "customer",
                table: "complement",
                column: "CustomerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_complement_CustomerId",
                schema: "customer",
                table: "complement");

            migrationBuilder.CreateIndex(
                name: "IX_complement_CustomerId",
                schema: "customer",
                table: "complement",
                column: "CustomerId");
        }
    }
}
