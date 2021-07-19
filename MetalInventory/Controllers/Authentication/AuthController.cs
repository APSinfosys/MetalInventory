
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryRepository.Authentications;
using InventoryDal.DBOprations;
using System.Web.Security;

namespace MetalInventor.Controllers.Authentication
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        AuthenticationRepository repo = null;
        public AuthController()
        {
            repo = new AuthenticationRepository();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel lg)
        {
            var result = repo.Login(lg);
            if (result != null)
            {
                if(result=="0")
                {
                    FormsAuthentication.SetAuthCookie(lg.UserName, false);
                    TempData["Msg"] = "Login successfully";
                    return RedirectToAction("About", "Home");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(lg.UserName, false);
                    TempData["Msg"] = "Login successfully";
                    return RedirectToAction("Dashboard", "Home");
                }
                
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View();
        }


        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel rg)
        {
            int Result = 0;
            if (ModelState.IsValid)
            {
                int regId = repo.Register(rg);
                if (regId > 0)
                {
                    Result = 1;
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Record Added";
                }
                else
                {
                    Result = 0;
                }
            }
            if (Result == 1)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Auth");
        }



    }
}