using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scada.Migrations
{
    /// <inheritdoc />
    public partial class DataCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currentValue = table.Column<float>(type: "real", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalogInput_Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalogInput_IOAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalogInput_ScanTime = table.Column<int>(type: "int", nullable: true),
                    AnalogInput_OnOffScan = table.Column<bool>(type: "bit", nullable: true),
                    AnalogInput_LowLimit = table.Column<double>(type: "float", nullable: true),
                    AnalogInput_HighLimit = table.Column<double>(type: "float", nullable: true),
                    AnalogInput_Units = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalogOutput_IOAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalogOutput_InitialValue = table.Column<int>(type: "int", nullable: true),
                    LowLimit = table.Column<double>(type: "float", nullable: true),
                    HighLimit = table.Column<double>(type: "float", nullable: true),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitalInput_IOAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScanTime = table.Column<int>(type: "int", nullable: true),
                    OnOffScan = table.Column<bool>(type: "bit", nullable: true),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IOAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Alarms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    threshHold = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    analogId = table.Column<int>(type: "int", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    priority = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarms_Tag_analogId",
                        column: x => x.analogId,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastTagValues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tagId = table.Column<int>(type: "int", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    value = table.Column<float>(type: "real", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastTagValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PastTagValues_Tag_tagId",
                        column: x => x.tagId,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_analogId",
                table: "Alarms",
                column: "analogId");

            migrationBuilder.CreateIndex(
                name: "IX_PastTagValues_tagId",
                table: "PastTagValues",
                column: "tagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarms");

            migrationBuilder.DropTable(
                name: "PastTagValues");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
