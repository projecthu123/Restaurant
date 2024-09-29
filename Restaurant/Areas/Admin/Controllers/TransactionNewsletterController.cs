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
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletters { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> TransactionNewsletters)
        {
            this.TransactionNewsletters = TransactionNewsletters;
        }
        // GET: TransactionNewsletterController
        public ActionResult Index()
        {
            List<TransactionNewsletter> letter = TransactionNewsletters.View();

            var data = letter.Select(x => new TransactionNewsletterModel{
                TransactionNewsletterEmail = x.TransactionNewsletterEmail,
                TransactionNewsletterId = x.TransactionNewsletterId,
                
            }).ToList();


            return View(data);
        }

        // GET: TransactionNewsletterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionNewsletterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionNewsletterController/Create
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

        // GET: TransactionNewsletterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionNewsletterController/Edit/5
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

        // GET: TransactionNewsletterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionNewsletterController/Delete/5
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
