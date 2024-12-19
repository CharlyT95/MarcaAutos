using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcasAuto",
                columns: table => new
                {
                    Id1 = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Abreviatura = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcasAuto", x => x.Id1);
                });

            migrationBuilder.InsertData(
                table: "MarcasAuto",
                columns: new[] { "Id1", "Abreviatura", "Descripcion", "FechaCreacion", "Id" },
                values: new object[,]
                {
                    { 1, "Hyu", "Hyundai Motor Company fabricante Surcoreano", new DateTime(2024, 12, 19, 1, 21, 22, 864, DateTimeKind.Utc).AddTicks(2067), "Hyundai" },
                    { 2, "Nis", "Nissan fabricante Japones", new DateTime(2024, 12, 19, 1, 21, 22, 864, DateTimeKind.Utc).AddTicks(2637), "Nissan" },
                    { 3, "Toy", "Marca Toyota se fabrica en muchos lugares del mundo", new DateTime(2024, 12, 19, 1, 21, 22, 864, DateTimeKind.Utc).AddTicks(2639), "Toyota" },
                    { 4, "Kia", "Kia Motors  fabricante Surcoreano", new DateTime(2024, 12, 19, 1, 21, 22, 864, DateTimeKind.Utc).AddTicks(2640), "KIA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcasAuto");
        }
    }
}
