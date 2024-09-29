using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> TransactionContactUss { get; }

        public TransactionContactUsController(IRepository<TransactionContactUs> _TransactionContactUs)
        {
            TransactionContactUss = _TransactionContactUs;
        }

        // GET: TransactionContactUsController
        public ActionResult Index()
        {
            List<TransactionContactUs> contactus = TransactionContactUss.View();
            var data = contactus.Select(x => new TransactionContactUsModel
            {
                TransactionContactUsSubject = x.TransactionContactUsSubject,
                TransactionContactUsEmail = x.TransactionContactUsEmail,
                TransactionContactUsFullName = x.TransactionContactUsFullName,
                TransactionContactUsId = x.TransactionContactUsId,
                TransactionContactUsMessage = x.TransactionContactUsMessage,

            });



            return View(data);
        }

        // GET: TransactionContactUsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionContactUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TransactionContactUsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionContactUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: TransactionContactUsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionContactUsController/Delete/5
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
    }
}
