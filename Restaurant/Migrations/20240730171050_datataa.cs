using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class datataa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionContactUId",
                table: "TransactionContactUs",
                newName: "TransactionContactUsId");

            migrationBuilder.RenameColumn(
                name: "MasterSocialMediumId",
                table: "MasterSocialMedia",
                newName: "MasterSocialMediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionContactUsId",
                table: "TransactionContactUs",
                newName: "TransactionContactUId");

            migrationBuilder.RenameColumn(
                name: "MasterSocialMediaId",
                table: "MasterSocialMedia",
                newName: "MasterSocialMediumId");
        }
    }
}
