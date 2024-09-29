using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContect>();
builder.Services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterCategoryMenu>, MasterCategoryMenuRepository>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>, MasterContactUsInformationRepository>();
builder.Services.AddScoped<IRepository<MasterItemMenu>, MasterItemMenuRepository>();
builder.Services.AddScoped<IRepository<MasterOffer>, MasterOfferRepository>();
builder.Services.AddScoped<IRepository<TransactionNewsletter>, TransactionNewsletterRepository>();
builder.Services.AddScoped<IRepository<TransactionContactUs>, TransactionContactURepository>();
builder.Services.AddScoped<IRepository<MasterService>, MasterServiceRepository>();
builder.Services.AddScoped<IRepository<MasterSlider>, MasterSliderRepository>();
builder.Services.AddScoped<IRepository<TransactionBookTable>, TransactionBookTableRepository>();
builder.Services.AddScoped<IRepository<MasterPartner>, MasterPartnerRepository>();
builder.Services.AddScoped<IRepository<MasterWorkingHour>, MasterWorkingHourRepository>();
builder.Services.AddScoped<IRepository<MasterSocialMedia>, MasterSocialMediumRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
builder.Services.AddScoped<IRepository<FeedBack>, FeedBackRepository>();


builder.Services.AddDbContext<AppDbContect>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Admin/Account/Login";
});
var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

//app.MapControllerRoute(
//    name: "areas",
//   pattern: "{area=exist}/{controller=Home}/{action=Index}/{id?}"
//   );
//app.MapControllerRoute(
//    name: "default",
//   pattern: "{controller=Home}/{action=Index}/{id?}"
//   );

app.MapControllerRoute(

    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
