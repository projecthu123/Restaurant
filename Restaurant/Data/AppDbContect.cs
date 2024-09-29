using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Restaurant.Models;
using Restaurant.Areas.Admin.ViewModels;

namespace Restaurant.Data
{
    public class AppDbContect:IdentityDbContext
    {

        public AppDbContect(DbContextOptions<AppDbContect> options) :base(options)
        {
                
        }
        public virtual DbSet<MasterCategoryMenu> MasterCategoryMenus { get; set; }

        public virtual DbSet<MasterContactUsInformation> MasterContactUsInformations { get; set; }

        public virtual DbSet<MasterItemMenu> MasterItemMenus { get; set; }

        public virtual DbSet<MasterMenu> MasterMenus { get; set; }

        public virtual DbSet<MasterOffer> MasterOffers { get; set; }

        public virtual DbSet<MasterPartner> MasterPartners { get; set; }

        public virtual DbSet<MasterService> MasterServices { get; set; }

        public virtual DbSet<MasterSlider> MasterSliders { get; set; }

        public virtual DbSet<MasterSocialMedia> MasterSocialMedia { get; set; }

        public virtual DbSet<MasterWorkingHour> MasterWorkingHours { get; set; }

        public virtual DbSet<SystemSetting> SystemSettings { get; set; }

        public virtual DbSet<TransactionBookTable> TransactionBookTables { get; set; }

        public virtual DbSet<TransactionContactUs> TransactionContactUs { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }

        public virtual DbSet<TransactionNewsletter> TransactionNewsletters { get; set; }
        public DbSet<Restaurant.Areas.Admin.ViewModels.MasterCategoryMenuModel> MasterCategoryMenuModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.MasterOfferModel> MasterOfferModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.TransactionNewsletterModel> TransactionNewsletterModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.TransactionContactUsModel> TransactionContactUsModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.TransactionBookTableModel> TransactionBookTableModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.MasterServiceModel> MasterServiceModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.MasterSliderModel> MasterSliderModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.MasterPartnerModel> MasterPartnerModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.MasterWorkingHourModel> MasterWorkingHourModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.MasterSocialMediaModel> MasterSocialMediaModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.SystemSettingModel> SystemSettingModel { get; set; } = default!;
        public DbSet<Restaurant.Areas.Admin.ViewModels.FeedBackModel> FeedBackModel { get; set; } = default!;

       
    }
}
