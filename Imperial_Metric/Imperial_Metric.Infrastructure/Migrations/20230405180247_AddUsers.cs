using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imperial_Metric.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "138021cb-6ee4-4602-b599-95cc5a4063da");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "1d78ec2d-bea4-4a69-b933-fb39a7043bb2");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "4535ccaa-d228-4022-b6c1-acaf934134b6");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "497b6bc5-9a89-480c-9419-8346c01c40ea");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "54d95a13-9830-4355-8e22-aefae3a3b033");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "5d4d83d5-baea-4d38-bd5b-b315b99ff487");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "7abdf623-4995-44a2-abd2-3fcb51dbb303");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "9c9d33f3-c705-4e23-9d78-c85800043173");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "a0001d7e-f30e-49c2-bc65-7d5b5881dc94");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "a56f04c3-d01a-4ffb-a4f4-0bc87f052903");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "a96e8f04-5391-4b6c-8631-6dbb326aaab5");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "c9ae47f1-1c7e-4807-8604-e669bf288f59");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "e63e9a1e-8c76-469a-bc9b-481cd30604be");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConversionsRates",
                columns: new[] { "Id", "ConversionFactor", "ConversionId", "ConversionOffset", "FromUnit", "Name", "ToUnit" },
                values: new object[,]
                {
                    { "086eaeab-82e0-4011-aebe-c53cb6a636dc", 0.30480000000000002, 1, 0.0, "Feet", "Feet to Meters", "Meters" },
                    { "13df1109-8030-45a1-9d9f-6f2ae5abea67", 0.000145038, 5, 0.0, "Pascals", "Pascals to PSI", "PSI" },
                    { "325898d5-5345-4c31-b0bb-27c70b67b2c3", 0.55555555560000003, 4, -32.0, "Fahrenheit", "Fahrenheit to Celsius", "Celsius" },
                    { "78da5326-cd36-4f8b-bce6-638b9803d77f", 6894.7600000000002, 5, 0.0, "PSI", "PSI to Pascals", "Pascals" },
                    { "8b913812-e46d-4f27-bb54-7781a12e7868", 2.2046199999999998, 2, 0.0, "Kilograms", "Kilograms to Pounds", "Pounds" },
                    { "9c47df94-775e-434e-8cf4-43365a8d3ce1", 1.60934, 3, 0.0, "Miles per hour", "Miles to Kilometers", "Kilometers per hour" },
                    { "ac8cf8f2-24e1-4d00-9a34-0e45f40767e8", 0.62137100000000001, 3, 0.0, "Kilometers per hour", "Kilometers to Miles", "Miles per hour" },
                    { "c0a91389-02d4-4cdf-8617-1cfcc26710a7", 1.09361, 1, 0.0, "Meters", "Meters to Yard", "Yard" },
                    { "c235365c-d650-4878-8f08-7283d235e12d", 3.7854100000000002, 6, 0.0, "Gallons", "Gallons to Liters", "Liters" },
                    { "ca85a610-758f-4084-9f59-01b14bbe1096", 1.8, 4, 32.0, "Celsius", "Celsius to Fahrenheit", "Fahrenheit" },
                    { "d7106147-1919-4ee0-b2b4-7e71c3fd0cf6", 0.26417200000000002, 6, 0.0, "Liters", "Liters to Gallons", "Gallons" },
                    { "db39c82b-7c59-4ae0-a2f1-55e5c259cbca", 0.453592, 2, 0.0, "Pounds", "Pounds to Kilograms", "Kilograms" },
                    { "e6cd08d6-1f56-421a-8739-cd341c375304", 3.2808398950000002, 1, 0.0, "Meters", "Meters to Feet", "Feet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "086eaeab-82e0-4011-aebe-c53cb6a636dc");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "13df1109-8030-45a1-9d9f-6f2ae5abea67");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "325898d5-5345-4c31-b0bb-27c70b67b2c3");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "78da5326-cd36-4f8b-bce6-638b9803d77f");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "8b913812-e46d-4f27-bb54-7781a12e7868");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "9c47df94-775e-434e-8cf4-43365a8d3ce1");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "ac8cf8f2-24e1-4d00-9a34-0e45f40767e8");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "c0a91389-02d4-4cdf-8617-1cfcc26710a7");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "c235365c-d650-4878-8f08-7283d235e12d");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "ca85a610-758f-4084-9f59-01b14bbe1096");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "d7106147-1919-4ee0-b2b4-7e71c3fd0cf6");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "db39c82b-7c59-4ae0-a2f1-55e5c259cbca");

            migrationBuilder.DeleteData(
                table: "ConversionsRates",
                keyColumn: "Id",
                keyValue: "e6cd08d6-1f56-421a-8739-cd341c375304");

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
        }
    }
}
