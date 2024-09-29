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
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffers { get; }
        public UserManager<IdentityUser> UserManagers { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer> MasterOffers,UserManager<IdentityUser> UserManagers, Microsoft.AspNetCore.Hosting.IHostingEnvironment Host)
        {
            this.MasterOffers = MasterOffers;
            this.UserManagers = UserManagers;
            this.Host = Host;
        }

        // GET: MasterOfferController
        public ActionResult Index()
        {
            List<MasterOffer> offers = MasterOffers.View();

    
               var offerModels = offers.Select(o => new MasterOfferModel
                 {
        // Map properties from o to your model here
       
                   MasterOfferBreef=o.MasterOfferBreef,
                   MasterOfferDesc=o.MasterOfferDesc,
                   MasterOfferId=o.MasterOfferId,
                   MasterOfferImageUrl=o.MasterOfferImageUrl,
                   MasterOfferTitle=o.MasterOfferTitle,
                   IsActive=o.IsActive,
                }).ToList();

            return View(offerModels);
        }

        // GET: MasterOfferController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterOfferModel collection)
        {
            try
            {
                string ImageSave = SaveImage(collection.Files);
                ImageSave = ImageSave != "" ? ImageSave : collection.MasterOfferImageUrl;
                var user =await UserManagers.FindByNameAsync(User.Identity.Name);
                var data = new MasterOffer
                {
                    MasterOfferBreef=collection.MasterOfferBreef,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferId= collection.MasterOfferId,
                    MasterOfferImageUrl = ImageSave,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    CreateId = user.Id,
                };

                MasterOffers.Add(data);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=MasterOffers.Find(id);

            var newdata = new MasterOfferModel
            {
                MasterOfferBreef= data.MasterOfferBreef,
                MasterOfferDesc= data.MasterOfferDesc,
                MasterOfferId= data.MasterOfferId,
                MasterOfferTitle= data.MasterOfferTitle,
                MasterOfferImageUrl= data.MasterOfferImageUrl,
            };


            return View(newdata);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterOfferModel collection)
        {
            try
            {
                string ImageSave = "";

                if (collection.Files != null)
                {
                    ImageSave = SaveImage(collection.Files);
                    ImageSave = ImageSave != "" ? ImageSave : collection.MasterOfferImageUrl;
                }
                else
                {
                    ImageSave = collection.MasterOfferImageUrl;
                }
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);

                var data= MasterOffers.Find(id);
                data.MasterOfferBreef= collection.MasterOfferBreef;
                data.MasterOfferDesc= collection.MasterOfferDesc;
                data.MasterOfferTitle= collection.MasterOfferTitle;
                data.MasterOfferImageUrl= ImageSave;
                data.EditDate= DateTime.Now;
                data.EditId = user.Id;

                MasterOffers.Update(id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterOfferController/Delete/5
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
            MasterOffers.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterOffers.Delete(idDelete, new Models.MasterOffer());
            return RedirectToAction(nameof(Index));
        }
    }



}
