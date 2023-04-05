using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imperial_Metric.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    conversionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConversionsRates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FromUnit = table.Column<string>(type: "text", nullable: false),
                    ToUnit = table.Column<string>(type: "text", nullable: false),
                    ConversionFactor = table.Column<double>(type: "double precision", nullable: false),
                    ConversionOffset = table.Column<double>(type: "double precision", nullable: false),
                    ConversionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionsRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversionsRates_Conversions_ConversionId",
                        column: x => x.ConversionId,
                        principalTable: "Conversions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conversions",
                columns: new[] { "Id", "conversionName" },
                values: new object[,]
                {
                    { 1, "Length" },
                    { 2, "Mass" },
                    { 3, "Speed" },
                    { 4, "Temperature" },
                    { 5, "Pressure" },
                    { 6, "Volume" }
                });

            migrationBuilder.InsertData(
                table: "ConversionsRates",
                columns: new[] { "Id", "ConversionFactor", "ConversionId", "ConversionOffset", "FromUnit", "Name", "ToUnit" },
                values: new object[,]
                {
                    { "138021cb-6ee4-4602-b599-95cc5a4063da", 1.60934, 3, 0.0, "Miles per hour", "Miles to Kilometers", "Kilometers per hour" },
                    { "1d78ec2d-bea4-4a69-b933-fb39a7043bb2", 0.000145038, 5, 0.0, "Pascals", "Pascals to PSI", "PSI" },
                    { "4535ccaa-d228-4022-b6c1-acaf934134b6", 0.62137100000000001, 3, 0.0, "Kilometers per hour", "Kilometers to Miles", "Miles per hour" },
                    { "497b6bc5-9a89-480c-9419-8346c01c40ea", 0.30480000000000002, 1, 0.0, "Feet", "Feet to Meters", "Meters" },
                    { "54d95a13-9830-4355-8e22-aefae3a3b033", 2.2046199999999998, 2, 0.0, "Kilograms", "Kilograms to Pounds", "Pounds" },
                    { "5d4d83d5-baea-4d38-bd5b-b315b99ff487", 3.2808398950000002, 1, 0.0, "Meters", "Meters to Feet", "Feet" },
                    { "7abdf623-4995-44a2-abd2-3fcb51dbb303", 1.09361, 1, 0.0, "Meters", "Meters to Yard", "Yard" },
                    { "9c9d33f3-c705-4e23-9d78-c85800043173", 0.453592, 2, 0.0, "Pounds", "Pounds to Kilograms", "Kilograms" },
                    { "a0001d7e-f30e-49c2-bc65-7d5b5881dc94", 0.26417200000000002, 6, 0.0, "Liters", "Liters to Gallons", "Gallons" },
                    { "a56f04c3-d01a-4ffb-a4f4-0bc87f052903", 6894.7600000000002, 5, 0.0, "PSI", "PSI to Pascals", "Pascals" },
                    { "a96e8f04-5391-4b6c-8631-6dbb326aaab5", 3.7854100000000002, 6, 0.0, "Gallons", "Gallons to Liters", "Liters" },
                    { "c9ae47f1-1c7e-4807-8604-e669bf288f59", 1.8, 4, 32.0, "Celsius", "Celsius to Fahrenheit", "Fahrenheit" },
                    { "e63e9a1e-8c76-469a-bc9b-481cd30604be", 0.55555555560000003, 4, -32.0, "Fahrenheit", "Fahrenheit to Celsius", "Celsius" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversionsRates_ConversionId",
                table: "ConversionsRates",
                column: "ConversionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Conversions");

            migrationBuilder.DropTable(
                name: "ConversionsRates");
        }
    }
}
