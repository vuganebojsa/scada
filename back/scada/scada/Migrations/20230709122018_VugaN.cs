﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scada.Migrations
{
    /// <inheritdoc />
    public partial class VugaN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Tag",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Tag");
        }
    }
}
