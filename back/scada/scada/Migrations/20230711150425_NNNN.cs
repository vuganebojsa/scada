using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scada.Migrations
{
    /// <inheritdoc />
    public partial class NNNN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_Tag_analogId",
                table: "Alarms");

            migrationBuilder.AlterColumn<int>(
                name: "analogId",
                table: "Alarms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_Tag_analogId",
                table: "Alarms",
                column: "analogId",
                principalTable: "Tag",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_Tag_analogId",
                table: "Alarms");

            migrationBuilder.AlterColumn<int>(
                name: "analogId",
                table: "Alarms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_Tag_analogId",
                table: "Alarms",
                column: "analogId",
                principalTable: "Tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
