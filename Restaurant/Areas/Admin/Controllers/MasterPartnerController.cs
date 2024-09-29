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
    [Authorize]
    [Area("Admin")]
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartners { get; }
        public UserManager<IdentityUser> UserManagers { get; }
        public IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> MasterPartners,UserManager<IdentityUser> UserManagers,IHostingEnvironment Host)
        {
            this.MasterPartners = MasterPartners;
            this.UserManagers = UserManagers;
            this.Host = Host;
        }

        // GET: MasterPartnerController
        public ActionResult Index()
        {
            List<MasterPartner> partner = MasterPartners.View();

            var data = partner.Select(x => new MasterPartnerModel
            {
                IsActive = x.IsActive,
                MasterPartnerId=x.MasterPartnerId,
                MasterPartnerLogoImageUrl=x.MasterPartnerLogoImageUrl,
                MasterPartnerName=x.MasterPartnerName,
                MasterPartnerWebsiteUrl=x.MasterPartnerWebsiteUrl,
                
            });



            return View(data);
        }

        // GET: MasterPartnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterPartnerModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                string ImageSave = SaveImage(collection.files);
                ImageSave = ImageSave != "" ? ImageSave : collection.MasterPartnerLogoImageUrl;

                var data = new MasterPartner
                {
                    CreateDate = DateTime.Now,
                    CreateId = user.Id,
                    MasterPartnerId=collection.MasterPartnerId,
                    MasterPartnerLogoImageUrl=ImageSave,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                };

                MasterPartners.Add(data);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartners.Find(id);
            var newdata = new MasterPartnerModel
            {
                MasterPartnerId=data.MasterPartnerId,
                MasterPartnerLogoImageUrl= data.MasterPartnerLogoImageUrl,
                MasterPartnerName= data.MasterPartnerName,
                MasterPartnerWebsiteUrl= data.MasterPartnerWebsiteUrl,
            };




            return View(newdata);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Edit(int id, MasterPartnerModel collection)
        {
            try
            {
                string ImageSave = "";

                if (collection.files != null)
                {
                    ImageSave = SaveImage(collection.files);
                    ImageSave = ImageSave != "" ? ImageSave : collection.MasterPartnerLogoImageUrl;
                }
                else
                {
                    ImageSave = collection.MasterPartnerLogoImageUrl;
                }
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
               

                var data = MasterPartners.Find(id);
                data.MasterPartnerName = collection.MasterPartnerName;
                data.MasterPartnerId = collection.MasterPartnerId;
                data.MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl;
                data.MasterPartnerLogoImageUrl=ImageSave;
                data.EditDate = DateTime.Now;
                data.EditId = user.Id;

                MasterPartners.Update(id, data);    

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterPartnerController/Delete/5
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
            MasterPartners.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterPartners.Delete(idDelete, new Models.MasterPartner());
            return RedirectToAction(nameof(Index));
        }
    }
}

