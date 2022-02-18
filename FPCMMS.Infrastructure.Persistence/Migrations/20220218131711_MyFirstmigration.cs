using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPCMMS.Infrastructure.Persistence.Migrations
{
    public partial class MyFirstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifies",
                columns: table => new
                {
                    NotifyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifies", x => x.NotifyId);
                });

            migrationBuilder.CreateTable(
                name: "NotifyItems",
                columns: table => new
                {
                    NotifyItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaponType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NotifyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyItems", x => x.NotifyItemId);
                    table.ForeignKey(
                        name: "FK_NotifyItems_Notifies_NotifyId",
                        column: x => x.NotifyId,
                        principalTable: "Notifies",
                        principalColumn: "NotifyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotifyItems_NotifyId",
                table: "NotifyItems",
                column: "NotifyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotifyItems");

            migrationBuilder.DropTable(
                name: "Notifies");
        }
    }
}
