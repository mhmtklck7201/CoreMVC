using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastResume.Data.Migrations
{
    public partial class addTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogLongDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogKeyWords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogCards_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCards_BlogCategoryId",
                table: "BlogCards",
                column: "BlogCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCards");

            migrationBuilder.DropTable(
                name: "BlogCategories");
        }
    }
}
