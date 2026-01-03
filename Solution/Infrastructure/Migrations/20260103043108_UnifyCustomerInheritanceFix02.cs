using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnifyCustomerInheritanceFix02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                schema: "customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Cpf",
                schema: "customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "FantasyName",
                schema: "customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "LegalName",
                schema: "customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Rg",
                schema: "customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "StateRegistration",
                schema: "customer",
                table: "customer");

            migrationBuilder.CreateTable(
                name: "company",
                schema: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    FantasyName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    LegalName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    StateRegistration = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_company_customer_Id",
                        column: x => x.Id,
                        principalSchema: "customer",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person",
                schema: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Rg = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_customer_Id",
                        column: x => x.Id,
                        principalSchema: "customer",
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company",
                schema: "customer");

            migrationBuilder.DropTable(
                name: "person",
                schema: "customer");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                schema: "customer",
                table: "customer",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                schema: "customer",
                table: "customer",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FantasyName",
                schema: "customer",
                table: "customer",
                type: "character varying(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "customer",
                table: "customer",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                schema: "customer",
                table: "customer",
                type: "character varying(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "customer",
                table: "customer",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                schema: "customer",
                table: "customer",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateRegistration",
                schema: "customer",
                table: "customer",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true);
        }
    }
}
