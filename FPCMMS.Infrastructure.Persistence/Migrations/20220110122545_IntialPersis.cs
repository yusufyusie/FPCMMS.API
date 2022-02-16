using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPCMMS.Infrastructure.Persistence.Migrations
{
    public partial class IntialPersis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotifyWeapons",
                columns: table => new
                {
                    NotifyWeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyWeapons", x => x.NotifyWeaponId);
                });

            migrationBuilder.InsertData(
                table: "NotifyWeapons",
                columns: new[] { "NotifyWeaponId", "Attachment", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "Quantity", "Type" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "/gunshgut.png", null, null, "Made in Turkey", null, null, "Sniper", 0, "AK-47, MD 2021" });

            migrationBuilder.InsertData(
                table: "NotifyWeapons",
                columns: new[] { "NotifyWeaponId", "Attachment", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "Quantity", "Type" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "/weapon.png", null, null, "Made in Turkey", null, null, "Gun", 0, "AK-47, MD 2021" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotifyWeapons");
        }
    }
}
