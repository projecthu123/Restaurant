using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;

namespace Restaurant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManagers { get; }
        public SignInManager<IdentityUser> SignInManagers { get; }
        public AccountController(UserManager<IdentityUser> UserManagers,SignInManager<IdentityUser> SignInManagers)
        {
            this.UserManagers = UserManagers;
            this.SignInManagers = SignInManagers;
        }

      


        // GET: AccountController
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View();
                }

                var user = new IdentityUser
                {
                    Email = collection.Email,
                    UserName= collection.Email,

                };

                var result= await UserManagers.CreateAsync(user,collection.Password);

                if (result.Succeeded)
                {
                  await  SignInManagers.SignInAsync(user,isPersistent:false);
                    return RedirectToAction("Index","Home", new { area = "Admin" });

                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View();
                }



                var result = await SignInManagers.PasswordSignInAsync(collection.Email,collection.Password,isPersistent:collection.RememberMe,lockoutOnFailure:false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }

                TempData["wrong-alert"] = "Wrong Email Or Password";
                return View();
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
         await   SignInManagers.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        //// GET: AccountController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AccountController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AccountController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AccountController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AccountController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AccountController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AccountController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
