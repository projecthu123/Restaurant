using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterServices { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }
        public UserManager<IdentityUser> UserManagers { get; }

        public MasterServiceController(IRepository<MasterService> MasterServices,Microsoft.AspNetCore.Hosting.IHostingEnvironment Host,UserManager<IdentityUser> UserManagers)
        {
            this.MasterServices = MasterServices;
            this.Host = Host;
            this.UserManagers = UserManagers;
        }
        // GET: MasterServiceController
        public ActionResult Index()
        {
            List<MasterService> service = MasterServices.View();
            var data = service.Select(x => new MasterServiceModel
            {
                MasterServiceId = x.MasterServiceId,
                MasterServicesDesc = x.MasterServicesDesc,
                MasterServicesImage = x.MasterServicesImage,
                MasterServicesTitle = x.MasterServicesTitle,
                Icon=x.ICon,
                IsActive = x.IsActive,
            });


            return View(data);
        }

        // GET: MasterServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterServiceModel collection)
        {
            try
            {
                string ImageSave = SaveImage(collection.files);
                ImageSave = ImageSave != "" ? ImageSave : collection.MasterServicesImage;
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                var data = new MasterService
                {
                    MasterServiceId=collection.MasterServiceId,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesImage = ImageSave,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    IsActive = collection.IsActive,
                    ICon=collection.Icon,
                    CreateDate=DateTime.Now,
                    CreateId=user.Id,
                };
                MasterServices.Add(data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterServices.Find(id);
            var newdata = new MasterServiceModel
            {
                MasterServiceId = data.MasterServiceId,
                MasterServicesDesc=data.MasterServicesDesc,
                MasterServicesImage=data.MasterServicesImage,
                MasterServicesTitle=data.MasterServicesTitle,
                Icon=data.ICon,
               
            };


            return View(newdata);
        }

        // POST: MasterServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterServiceModel collection)
        {
            try
            {
                string ImageSave = "";

                if (collection.files != null)
                {
                    ImageSave = SaveImage(collection.files);
                    ImageSave = ImageSave != "" ? ImageSave : collection.MasterServicesImage;
                }
                else
                {
                    ImageSave = collection.MasterServicesImage;
                }
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);



                var data = MasterServices.Find(id);
                data.MasterServicesTitle=collection.MasterServicesTitle;
                data.MasterServicesDesc=collection.MasterServicesDesc;
                data.MasterServiceId=collection.MasterServiceId;
                data.EditDate = DateTime.Now;
                data.EditId = user.Id;
                data.ICon=collection.Icon;
                data.MasterServicesImage = ImageSave;

                MasterServices.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterServiceController/Delete/5
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
            MasterServices.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterServices.Delete(idDelete, new Models.MasterService());
            return RedirectToAction(nameof(Index));
        }
    }
}
