using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsHeadless.Migrations.CmsHeadlessDb
{
    public partial class Add_LogType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LogTypeLog_typeID",
                table: "LogEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LogType",
                columns: table => new
                {
                    Log_typeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Log_typeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Log_typeCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogType", x => x.Log_typeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogEvent_LogTypeLog_typeID",
                table: "LogEvent",
                column: "LogTypeLog_typeID");

            migrationBuilder.AddForeignKey(
                name: "FK_LogEvent_LogType_LogTypeLog_typeID",
                table: "LogEvent",
                column: "LogTypeLog_typeID",
                principalTable: "LogType",
                principalColumn: "Log_typeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogEvent_LogType_LogTypeLog_typeID",
                table: "LogEvent");

            migrationBuilder.DropTable(
                name: "LogType");

            migrationBuilder.DropIndex(
                name: "IX_LogEvent_LogTypeLog_typeID",
                table: "LogEvent");

            migrationBuilder.DropColumn(
                name: "LogTypeLog_typeID",
                table: "LogEvent");
        }
    }
}
