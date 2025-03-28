using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name_Common = table.Column<string>(type: "TEXT", nullable: false),
                    Name_Official = table.Column<string>(type: "TEXT", nullable: false),
                    Cca2 = table.Column<string>(type: "TEXT", nullable: false),
                    Capital = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    Subregion = table.Column<string>(type: "TEXT", nullable: false),
                    Area = table.Column<double>(type: "REAL", nullable: false),
                    Population = table.Column<int>(type: "INTEGER", nullable: false),
                    Currencies = table.Column<string>(type: "TEXT", nullable: false),
                    Languages = table.Column<string>(type: "TEXT", nullable: false),
                    Timezones = table.Column<string>(type: "TEXT", nullable: false),
                    Independent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Flags_Png = table.Column<string>(type: "TEXT", nullable: false),
                    Maps_GoogleMaps = table.Column<string>(type: "TEXT", nullable: false),
                    Maps_OpenStreetMaps = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryDetails");
        }
    }
}
