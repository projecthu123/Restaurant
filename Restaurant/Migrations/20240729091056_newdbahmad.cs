using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class newdbahmad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionNewsletters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "TransactionNewsletters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionNewsletters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "TransactionNewsletters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionNewsletters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionNewsletters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionContactUs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "TransactionContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionContactUs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "TransactionContactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionBookTables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "TransactionBookTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionBookTables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "TransactionBookTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionBookTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionBookTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "SystemSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "SystemSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterWorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "MasterWorkingHours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterWorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "MasterWorkingHours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterWorkingHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterWorkingHours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterSocialMedia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterSocialMedia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterSocialMedia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterSocialMedia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "MasterSliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterSliders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "MasterSliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterSliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterSliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "MasterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "MasterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "MasterOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "MasterOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterOffers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterOffers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterContactUsInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "MasterContactUsInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterContactUsInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "MasterContactUsInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterContactUsInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterContactUsInformations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MasterCategoryMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "MasterCategoryMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "MasterCategoryMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "MasterCategoryMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MasterCategoryMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MasterCategoryMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionContactUs");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionBookTables");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterWorkingHours");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterSocialMedia");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterSliders");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterServices");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterOffers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterContactUsInformations");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "MasterContactUsInformations");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterContactUsInformations");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "MasterContactUsInformations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterContactUsInformations");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterContactUsInformations");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MasterCategoryMenus");
        }
    }
}
