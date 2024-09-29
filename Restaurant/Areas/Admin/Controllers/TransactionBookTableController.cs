using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTables { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> TransactionBookTables)
        {
            this.TransactionBookTables = TransactionBookTables;
        }
        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            List<TransactionBookTable> books = TransactionBookTables.View();
            var data = books.Select(x => new TransactionBookTableModel
            {
                TransactionBookTableDate = x.TransactionBookTableDate,
                TransactionBookTableEmail = x.TransactionBookTableEmail,
                TransactionBookTableFullName = x.TransactionBookTableFullName,
                TransactionBookTableId = x.TransactionBookTableId,
                TransactionBookTableMobileNumber = x.TransactionBookTableMobileNumber,
                
            }
            
                
            );
            


            return View(data);
        }

        // GET: TransactionBookTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionBookTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionBookTableController/Create
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

        // GET: TransactionBookTableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionBookTableController/Edit/5
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

        // GET: TransactionBookTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionBookTableController/Delete/5
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
