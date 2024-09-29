using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Views
{
    [Authorize]
    [Area("Admin")]
    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> MasterWorkingHours { get; }
        public UserManager<IdentityUser> UserManagers { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> MasterWorkingHours,UserManager<IdentityUser>userManagers)
        {
            this.MasterWorkingHours = MasterWorkingHours;
            UserManagers = userManagers;
        }

        // GET: MasterWorkingHourController
        public ActionResult Index()
        {
            List<MasterWorkingHour> master = MasterWorkingHours.View();

            var data = master.Select(x => new MasterWorkingHourModel
            {
                MasterWorkingHourId = x.MasterWorkingHourId,
                MasterWorkingHoursIdName = x.MasterWorkingHoursIdName,
                IsActive = x.IsActive,
                MasterWorkingHoursIdTimeFormTo=x.MasterWorkingHoursIdTimeFormTo,
                
            });



            return View(data);
        }

        // GET: MasterWorkingHourController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterWorkingHourController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterWorkingHourModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                var data = new MasterWorkingHour
                {
                    MasterWorkingHourId = collection.MasterWorkingHourId,
                    MasterWorkingHoursIdName = collection.MasterWorkingHoursIdName,
                    MasterWorkingHoursIdTimeFormTo = collection.MasterWorkingHoursIdTimeFormTo,
                    CreateDate = DateTime.Now,
                    CreateId = user.Id,
                };

                MasterWorkingHours.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=MasterWorkingHours.Find(id);

            var newdata = new MasterWorkingHourModel{
                MasterWorkingHourId=data.MasterWorkingHourId,
                MasterWorkingHoursIdName=data.MasterWorkingHoursIdName,
                MasterWorkingHoursIdTimeFormTo=data.MasterWorkingHoursIdTimeFormTo,
            };

            return View(newdata);
        }

        // POST: MasterWorkingHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterWorkingHourModel collection)
        {
            try
            {
                var user = await UserManagers.FindByNameAsync(User.Identity.Name);
                var data = MasterWorkingHours.Find(id);
                data.EditDate = DateTime.Now;
                data.EditId = user.Id;
                data.MasterWorkingHourId=collection.MasterWorkingHourId;
                data.MasterWorkingHoursIdName = collection.MasterWorkingHoursIdName;
                data.MasterWorkingHoursIdTimeFormTo=collection.MasterWorkingHoursIdTimeFormTo;

                MasterWorkingHours.Update(id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterWorkingHourController/Delete/5
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
        public ActionResult Active(int id)
        {
            MasterWorkingHours.Active(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult IsDelete(int idDelete)
        {
            MasterWorkingHours.Delete(idDelete, new Models.MasterWorkingHour());
            return RedirectToAction(nameof(Index));
        }
    }
}
