using Microsoft.EntityFrameworkCore.Migrations;

namespace OccupationMicroservice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "OccupationRatings",
                schema: "dbo",
                columns: table => new
                {
                    OccupationRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationRatingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationRatings", x => x.OccupationRatingId);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                schema: "dbo",
                columns: table => new
                {
                    OccupationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationRatingId = table.Column<int>(type: "int", nullable: false),
                    OccupationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.OccupationId);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "OccupationRatings",
                columns: new[] { "OccupationRatingId", "Factor", "OccupationRatingName" },
                values: new object[,]
                {
                    { 1, 1.00m, "Professional" },
                    { 2, 1.25m, "White Collar" },
                    { 3, 1.50m, "Light Manual" },
                    { 4, 1.75m, "Heavy Manual" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Occupations",
                columns: new[] { "OccupationId", "OccupationName", "OccupationRatingId" },
                values: new object[,]
                {
                    { 1, "Cleaner", 3 },
                    { 2, "Doctor", 1 },
                    { 3, "Author", 2 },
                    { 4, "Farmer", 4 },
                    { 5, "Mechanic", 4 },
                    { 6, "Florist", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OccupationRatings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Occupations",
                schema: "dbo");
        }
    }
}
