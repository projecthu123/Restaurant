using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class newdbahnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterSliderUrl2",
                table: "MasterSliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MasterCategoryMenuModel",
                columns: table => new
                {
                    MasterCategoryMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterCategoryMenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCategoryMenuModel", x => x.MasterCategoryMenuId);
                });

            migrationBuilder.CreateTable(
                name: "MasterOfferModel",
                columns: table => new
                {
                    MasterOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterOfferTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterOfferBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterOfferDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterOfferImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterOfferModel", x => x.MasterOfferId);
                });

            migrationBuilder.CreateTable(
                name: "MasterPartnerModel",
                columns: table => new
                {
                    MasterPartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPartnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPartnerLogoImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPartnerWebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPartnerModel", x => x.MasterPartnerId);
                });

            migrationBuilder.CreateTable(
                name: "MasterServiceModel",
                columns: table => new
                {
                    MasterServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterServicesTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServicesDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServicesImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterServiceModel", x => x.MasterServiceId);
                });

            migrationBuilder.CreateTable(
                name: "MasterSliderModel",
                columns: table => new
                {
                    MasterSliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterSliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterSliderBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterSliderDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterSliderUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterSliderUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSliderModel", x => x.MasterSliderId);
                });

            migrationBuilder.CreateTable(
                name: "MasterSocialMediaModel",
                columns: table => new
                {
                    MasterSocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterSocialMediaImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterSocialMediaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSocialMediaModel", x => x.MasterSocialMediaId);
                });

            migrationBuilder.CreateTable(
                name: "MasterWorkingHourModel",
                columns: table => new
                {
                    MasterWorkingHourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterWorkingHoursIdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterWorkingHoursIdTimeFormTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterWorkingHourModel", x => x.MasterWorkingHourId);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettingModel",
                columns: table => new
                {
                    SystemSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemSettingLogoImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingLogoImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingCopyright = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingMapLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettingModel", x => x.SystemSettingId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionBookTableModel",
                columns: table => new
                {
                    TransactionBookTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionBookTableFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionBookTableEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionBookTableMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionBookTableDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionBookTableModel", x => x.TransactionBookTableId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionContactUsModel",
                columns: table => new
                {
                    TransactionContactUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionContactUsFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionContactUsModel", x => x.TransactionContactUsId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionNewsletterModel",
                columns: table => new
                {
                    TransactionNewsletterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionNewsletterEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionNewsletterModel", x => x.TransactionNewsletterId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterCategoryMenuModel");

            migrationBuilder.DropTable(
                name: "MasterOfferModel");

            migrationBuilder.DropTable(
                name: "MasterPartnerModel");

            migrationBuilder.DropTable(
                name: "MasterServiceModel");

            migrationBuilder.DropTable(
                name: "MasterSliderModel");

            migrationBuilder.DropTable(
                name: "MasterSocialMediaModel");

            migrationBuilder.DropTable(
                name: "MasterWorkingHourModel");

            migrationBuilder.DropTable(
                name: "SystemSettingModel");

            migrationBuilder.DropTable(
                name: "TransactionBookTableModel");

            migrationBuilder.DropTable(
                name: "TransactionContactUsModel");

            migrationBuilder.DropTable(
                name: "TransactionNewsletterModel");

            migrationBuilder.DropColumn(
                name: "MasterSliderUrl2",
                table: "MasterSliders");
        }
    }
}
