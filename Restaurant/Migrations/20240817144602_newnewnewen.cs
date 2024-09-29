using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class newnewnewen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuInfo",
                table: "MasterItemMenus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeedBack",
                columns: table => new
                {
                    FeedBackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedBackMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedBackImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedBackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedBackRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBack", x => x.FeedBackId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBack");

            migrationBuilder.DropColumn(
                name: "MasterItemMenuInfo",
                table: "MasterItemMenus");
        }
    }
}
