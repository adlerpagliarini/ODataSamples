using Microsoft.EntityFrameworkCore.Migrations;

namespace ODataSamples.Migrations
{
    public partial class Goal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_Developer_UserId",
                        column: x => x.UserId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goal_UserId",
                table: "Goal",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goal");
        }
    }
}
