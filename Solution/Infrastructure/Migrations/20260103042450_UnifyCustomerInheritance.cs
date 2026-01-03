using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnifyCustomerInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_complement_company_CustomerId",
                schema: "customer",
                table: "complement");

            migrationBuilder.DropForeignKey(
                name: "FK_complement_person_CustomerId",
                schema: "customer",
                table: "complement");

            migrationBuilder.DropTable(
                name: "company",
                schema: "customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person",
                schema: "customer",
                table: "person");

            migrationBuilder.RenameTable(
                name: "person",
                schema: "customer",
                newName: "customer",
                newSchema: "customer");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                schema: "customer",
                table: "customer",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "customer",
                table: "customer",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                schema: "customer",
                table: "customer",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                schema: "customer",
                table: "customer",
                type: "character varying(14)",
                maxLength: 14,
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
                name: "StateRegistration",
                schema: "customer",
                table: "customer",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                schema: "customer",
                table: "customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_complement_customer_CustomerId",
                schema: "customer",
                table: "complement",
                column: "CustomerId",
                principalSchema: "customer",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_complement_customer_CustomerId",
                schema: "customer",
                table: "complement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                schema: "customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Cnpj",
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
                name: "StateRegistration",
                schema: "customer",
                table: "customer");

            migrationBuilder.RenameTable(
                name: "customer",
                schema: "customer",
                newName: "person",
                newSchema: "customer");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                schema: "customer",
                table: "person",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "customer",
                table: "person",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                schema: "customer",
                table: "person",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_person",
                schema: "customer",
                table: "person",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "company",
                schema: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    CustomerType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FantasyName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LegalName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    StateRegistration = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_complement_company_CustomerId",
                schema: "customer",
                table: "complement",
                column: "CustomerId",
                principalSchema: "customer",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_complement_person_CustomerId",
                schema: "customer",
                table: "complement",
                column: "CustomerId",
                principalSchema: "customer",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
