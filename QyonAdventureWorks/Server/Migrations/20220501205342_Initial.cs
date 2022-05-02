using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QyonAdventureWorks.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TemperaturaCorporal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetidorId = table.Column<int>(type: "int", nullable: false),
                    PistaId = table.Column<int>(type: "int", nullable: false),
                    DataCorrida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempoGasto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pistas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Competidores",
                columns: new[] { "Id", "Altura", "Nome", "Peso", "Sexo", "TemperaturaCorporal" },
                values: new object[,]
                {
                    { 1, 1.85m, "Pedro Matinelli", 85m, "M", 37m },
                    { 2, 1.80m, "Bruno Amparo", 90m, "M", 36.8m },
                    { 3, 1.70m, "Marcela Fontes", 70m, "F", 36.5m }
                });

            migrationBuilder.InsertData(
                table: "Historicos",
                columns: new[] { "Id", "CompetidorId", "DataCorrida", "PistaId", "TempoGasto" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 5, 1, 17, 53, 41, 812, DateTimeKind.Local).AddTicks(7767), 1, 1.30m },
                    { 2, 1, new DateTime(2022, 5, 1, 17, 53, 41, 812, DateTimeKind.Local).AddTicks(7777), 2, 1.50m },
                    { 3, 2, new DateTime(2022, 5, 1, 17, 53, 41, 812, DateTimeKind.Local).AddTicks(7778), 2, 1.40m }
                });

            migrationBuilder.InsertData(
                table: "Pistas",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Pista com 5 curvas acentuadas dentro da cidade!" },
                    { 2, "Pista com percurso Rural!" },
                    { 3, "Pista percurso rally com rampa!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "Historicos");

            migrationBuilder.DropTable(
                name: "Pistas");
        }
    }
}
