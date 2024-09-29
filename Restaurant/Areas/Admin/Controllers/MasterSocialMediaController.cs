using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterSocialMediaController : Controller
    {
        public IRepository<MasterSocialMedia> MasterSocialMedias { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }
        public UserManager<IdentityUser> UserManagers { get; }

        public MasterSocialMediaController(IRepository<MasterSocialMedia> MasterSocialMedias, Microsoft.AspNetCore.Hosting.IHostingEnvironment Host, UserManager<IdentityUser> UserManagers)
        {
            this.MasterSocialMedias = MasterSocialMedias;
            this.Host = Host;
            this.UserManagers = UserManagers;
        }


        // GET: MasterSocialMediaController
        public ActionResult Index()
        {
            List<MasterSocialMedia> master = MasterSocialMedias.View();
            var data = master.Select(x => new MasterSocialMediaModel
            {
                ISActive = x.IsActive,
                MasterSocialMediaId = x.MasterSocialMediaId,
                MasterSocialMediaImageUrl = x.MasterSocialMediaImageUrl,

                MasterSocialMediaUrl = x.MasterSocialMediaUrl,
            });


            return View(data);
        }

        // GET: MasterSocialMediaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterSocialMediaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterSocialMediaModel collection)
        {
            try
            {
                string ImageSave = SaveImage(collection.files);
                ImageSave = ImageSave != "" ? ImageSave : collection.MasterSocialMediaImageUrl;
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);

                var data = new MasterSocialMedia
                {
                    MasterSocialMediaId = collection.MasterSocialMediaId,
                    MasterSocialMediaImageUrl = collection.MasterSocialMediaImageUrl,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    CreateDate = DateTime.Now,
                    CreateId = user.Id
                };
                MasterSocialMedias.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedias.Find(id);
            var newdata = new MasterSocialMediaModel
            {
                MasterSocialMediaId=data.MasterSocialMediaId,
                MasterSocialMediaImageUrl=data.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl=data.MasterSocialMediaUrl,
            };


            return View(newdata);
        }

        // POST: MasterSocialMediaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterSocialMediaModel collection)
        {
            try
            {
                string ImageSave = "";

                if (collection.files != null)
                {
                    ImageSave = SaveImage(collection.files  );
                    ImageSave = ImageSave != "" ? ImageSave : collection.MasterSocialMediaImageUrl;
                }
                else
                {
                    ImageSave = collection.MasterSocialMediaImageUrl;
                }
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);

                var data = MasterSocialMedias.Find(id);
                data.MasterSocialMediaImageUrl = collection.MasterSocialMediaImageUrl;
                data.EditDate = DateTime.Now;
                data.EditId = user.Id;
               data.MasterSocialMediaId=collection.MasterSocialMediaId;
                data.MasterSocialMediaUrl=collection.MasterSocialMediaUrl;

                MasterSocialMedias.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterSocialMediaController/Delete/5
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
            MasterSocialMedias.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterSocialMedias.Delete(idDelete, new Models.MasterSocialMedia());
            return RedirectToAction(nameof(Index));
        }
    }
}
