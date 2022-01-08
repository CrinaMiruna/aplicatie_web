using Microsoft.EntityFrameworkCore.Migrations;

namespace aplicatie_web.Migrations
{
    public partial class programareCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CabinetId",
                table: "programare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cabinet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinetNume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "programareCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    programareID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programareCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_programareCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programareCategory_programare_programareID",
                        column: x => x.programareID,
                        principalTable: "programare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_programare_CabinetId",
                table: "programare",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_programareCategory_CategoryID",
                table: "programareCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_programareCategory_programareID",
                table: "programareCategory",
                column: "programareID");

            migrationBuilder.AddForeignKey(
                name: "FK_programare_Cabinet_CabinetId",
                table: "programare",
                column: "CabinetId",
                principalTable: "Cabinet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_programare_Cabinet_CabinetId",
                table: "programare");

            migrationBuilder.DropTable(
                name: "Cabinet");

            migrationBuilder.DropTable(
                name: "programareCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_programare_CabinetId",
                table: "programare");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "programare");
        }
    }
}
