using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System.Security.Claims;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenus { get; }
        public UserManager<IdentityUser> UserManagers { get; }

        public MasterMenuController(IRepository<MasterMenu> MasterMenus,UserManager<IdentityUser> UserManagers)
        {
            this.MasterMenus = MasterMenus;
            this.UserManagers = UserManagers;
        }

        // GET: MasterMenuController
        public ActionResult Index()
        {

            List<MasterMenu> menu = MasterMenus.View();

            var data = menu.Select(x => new MasterMenuModel
            {
                IsActive = x.IsActive,
                MasterMenuId = x.MasterMenuId,
                MasterMenuName = x.MasterMenuName,
                MasterMenuUrl = x.MasterMenuUrl,
            });

            return View(data);
        }

        // GET: MasterMenuController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterMenus.View();
            return View(data);
        }

        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterMenuModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);

                var data = new MasterMenu
                {
MasterMenuId=collection.MasterMenuId,
MasterMenuName=collection.MasterMenuName,   
MasterMenuUrl=collection.MasterMenuUrl,
CreateDate = DateTime.Now,
CreateId=user.Id,
                };

              
                MasterMenus.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data= MasterMenus.Find(id);
            var newdata = new MasterMenuModel
            {
                MasterMenuId=data.MasterMenuId,
                IsActive=data.IsActive,
                MasterMenuName=data.MasterMenuName,
                MasterMenuUrl=data.MasterMenuUrl,
            };


            return View(newdata);
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterMenuModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                var data = MasterMenus.Find(id);
                data.MasterMenuName=collection.MasterMenuName;
               
                data.MasterMenuUrl=collection.MasterMenuUrl;
                data.MasterMenuId=collection.MasterMenuId;
                data.EditDate=DateTime.Now;
                data.EditId = user.Id;

                MasterMenus.Update(id, data);
                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterMenuController/Delete/5
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
        public async Task<IActionResult> Active(int id)
        {
            var user = await UserManagers.FindByNameAsync(User.Identity.Name);
            var data = MasterMenus.Find(id);
            data.EditId = user.Id;
            MasterMenus.Active(id);

            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterMenus.Delete(idDelete, new Models.MasterMenu());
            return RedirectToAction(nameof(Index));
        }
    }
}
