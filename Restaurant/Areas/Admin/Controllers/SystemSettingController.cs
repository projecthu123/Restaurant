using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSettings { get; }
        public IHostingEnvironment Host { get; }
        public UserManager<IdentityUser> UserManagers { get; }

        public SystemSettingController(IRepository<SystemSetting> SystemSettings,IHostingEnvironment Host,UserManager<IdentityUser>userManagers)
        {
            this.SystemSettings = SystemSettings;
            this.Host = Host;
            UserManagers = userManagers;
        }

        // GET: SystemSettingController
        public ActionResult Index()
        {
            List<SystemSetting> system = SystemSettings.View();

            var data = system.Select(x=>new SystemSettingModel
            {
                SystemSettingId = x.SystemSettingId,
                SystemSettingCopyright = x.SystemSettingCopyright,
                SystemSettingLogoImageUrl = x.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = x.SystemSettingLogoImageUrl2,
                SystemSettingMapLocation = x.SystemSettingMapLocation,
                SystemSettingWelcomeNoteBreef=x.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc=x.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteImageUrl=x.SystemSettingWelcomeNoteImageUrl,
                SystemSettingWelcomeNoteTitle=x.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteUrl=x.SystemSettingWelcomeNoteUrl,
                Icon=x.Icon,
                IsActive= x.IsActive,
            });


            return View(data);
        }

        // GET: SystemSettingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SystemSettingModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                string logo1 = SaveImage(collection.files1);
                string logo2 = SaveImage(collection.files2);
                string ImageSave3 = SaveImage(collection.files3);
                logo1 = logo1 != "" ? logo1 : collection.SystemSettingLogoImageUrl;
                logo2 = logo2 != "" ? logo2 : collection.SystemSettingLogoImageUrl2;
                ImageSave3 = ImageSave3 != "" ? ImageSave3 : collection.SystemSettingWelcomeNoteImageUrl;


                var data = new SystemSetting
                {
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteImageUrl = ImageSave3,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingLogoImageUrl2 = logo2,
                    SystemSettingLogoImageUrl = logo1,
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    CreateDate = DateTime.Now,
                    CreateId = user.Id,
                    Icon=collection.Icon,

                };
                SystemSettings.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {

            var data= SystemSettings.Find(id);
            var newdata = new SystemSettingModel
            {
                SystemSettingCopyright= data.SystemSettingCopyright,
                SystemSettingId= data.SystemSettingId,
                SystemSettingLogoImageUrl= data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2  = data.SystemSettingLogoImageUrl2,
                SystemSettingMapLocation= data.SystemSettingMapLocation,
                SystemSettingWelcomeNoteBreef=data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc= data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteImageUrl= data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingWelcomeNoteTitle= data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteUrl= data.SystemSettingWelcomeNoteUrl,
                Icon=data.Icon,
                
            };


            return View(newdata);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SystemSettingModel collection)
        {
            try
            {
                string logo1=collection.SystemSettingLogoImageUrl;

                string logo2 = collection.SystemSettingLogoImageUrl2;
                string ImageSave3 = collection.SystemSettingWelcomeNoteImageUrl;

                if (collection.files1 != null )
                {
                    logo1 = SaveImage(collection.files1);
                    logo1 = logo1 != "" ? logo1 : collection.SystemSettingLogoImageUrl;
                    
                }
                if (collection.files2 != null)
                {
                    logo2 = SaveImage(collection.files2);
                    logo2 = logo2 != "" ? logo2 : collection.SystemSettingLogoImageUrl;

                }
                if (collection.files3 != null)
                {
                    ImageSave3 = SaveImage(collection.files3);
                    ImageSave3 = ImageSave3 != "" ? ImageSave3 : collection.SystemSettingLogoImageUrl;

                }
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                

                var data = SystemSettings.Find(id);
                data.SystemSettingWelcomeNoteBreef=collection.SystemSettingWelcomeNoteBreef;
                data.SystemSettingLogoImageUrl = logo1;
                data.SystemSettingLogoImageUrl2= logo2;
                data.SystemSettingWelcomeNoteImageUrl = ImageSave3;
                data.SystemSettingMapLocation = collection.SystemSettingMapLocation;
                data.SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc;
                data.SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl;
                data.SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle;
                data.SystemSettingId = collection.SystemSettingId;
                data.EditDate = DateTime.Now;
                data.EditId = user.Id;
                data.SystemSettingCopyright= collection.SystemSettingCopyright;
                data.Icon = collection.Icon;

                SystemSettings.Update(id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemSettingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public string SaveImage(IFormFile Files)
        {
            string ImageSave = "";
            if (Files != null)
            {

                string PathImage = Path.Combine(Host.WebRootPath, "images");
                FileInfo FileInfo = new FileInfo(Files.FileName);
                //ImageSave = DateTime.Now.ToString().Replace("-","").Replace("/","").Replace(":","").Replace(" ","") + FileInfo.Extension;
                ImageSave = Guid.NewGuid().ToString() + FileInfo.Extension;


                string FullPath = Path.Combine(PathImage, ImageSave);

                Files.CopyTo(new FileStream(FullPath, FileMode.Create));

            }
            return ImageSave;
        }
        public ActionResult Active(int id)
        {
            SystemSettings.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            SystemSettings.Delete(idDelete, new Models.SystemSetting());
            return RedirectToAction(nameof(Index));
        }
    }
}
