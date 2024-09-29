using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterContactUsInformationController : Controller
    {
        public UserManager<IdentityUser> UserManagers { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformations { get; }
        public IHostingEnvironment Host { get; set; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> MasterContactUsInformations, IHostingEnvironment Host, UserManager<IdentityUser> UserManagers)
        {
            this.MasterContactUsInformations = MasterContactUsInformations;
           this.Host = Host;
            this.UserManagers = UserManagers;
        }
        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {
            List < MasterContactUsInformation > master = MasterContactUsInformations.View();
            var data = master.Select(x => new MasterContactUsInformationModel
            {
                IsActive= x.IsActive,
                MasterContactUsInformationId    = x.MasterContactUsInformationId,
                MasterContactUsInformationIdesc = x.MasterContactUsInformationIdesc,
                MasterContactUsInformationImageUrl = x.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect=x.MasterContactUsInformationRedirect,
                MasterContactUsInformationTitle=x.MasterContactUsInformationTitle,
            });


            return View(data);
        }

        // GET: MasterContactUsInformationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterContactUsInformationModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                string ImageSave = SaveImage(collection.Files);
                ImageSave = ImageSave != "" ? ImageSave : collection.MasterContactUsInformationImageUrl;
                var data = new MasterContactUsInformation
                {
                    MasterContactUsInformationId=collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc=collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationImageUrl=collection.MasterContactUsInformationImageUrl,
                    MasterContactUsInformationTitle=collection.MasterContactUsInformationTitle,
                    MasterContactUsInformationRedirect=collection.MasterContactUsInformationRedirect,
                       CreateDate = DateTime.Now,
                    CreateId = user.Id,
                };

                MasterContactUsInformations.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=MasterContactUsInformations.Find(id);
            var newdata = new MasterContactUsInformationModel
            {
                MasterContactUsInformationId=data.MasterContactUsInformationId,
                MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc,
                MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
                MasterContactUsInformationTitle = data.MasterContactUsInformationTitle,

                
            };

            return View(newdata);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterContactUsInformationModel collection)
        {
            try
            {
                string ImageSave = "";
                if (collection.Files != null)
                {

                    ImageSave = SaveImage(collection.Files);
                    ImageSave = ImageSave != "" ? ImageSave : collection.MasterContactUsInformationImageUrl;
                   
                }
                else
                {
                    ImageSave=collection.MasterContactUsInformationImageUrl;
                }
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                var data = MasterContactUsInformations.Find(id);

                data.MasterContactUsInformationImageUrl = collection.MasterContactUsInformationImageUrl;
                data.MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc;
                data.MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect;
                data.MasterContactUsInformationId = collection.MasterContactUsInformationId;
                data.EditId = user.Id;
              data.MasterContactUsInformationTitle=collection.MasterContactUsInformationTitle;

                MasterContactUsInformations.Update(id, data);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Delete/5
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
            MasterContactUsInformations.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterContactUsInformations.Delete(idDelete, new Models.MasterContactUsInformation());
            return RedirectToAction(nameof(Index));
        }
    }
}
